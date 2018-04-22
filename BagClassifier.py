"""
Image processing assignment 4

File : Bag of features image classifier

Notes:
+ All the kernels used are odd an symmetric [3x3, 5x5, ....]
+ Helper functions are added here for readability
+ Some functions have their name changed for readability

Dependencies:
+ numpy
+ opencv [cv2]
+ sklearn
+ matplotlib
"""

import cv2
import pylab
import numpy as np
from sklearn.preprocessing import StandardScaler
from sklearn import svm
from sklearn.cluster import KMeans
import os

# For readability
read = cv2.imread

# Helper funnctions goes here
def show(img_lst, lbl_lst=None, bin_img=True):
    """
    Attempts to show two images at the same line
    
    ## Arguments
    img_list : the two image objects [np.array] to be shown [left, right]
    lbl_lst  : the text to be shown over each subplot
    """
    num_imgs = len(img_lst)
    if lbl_lst is None: lbl_lst = ['']*num_imgs
    if len(lbl_lst) != num_imgs: raise ValueError('too much/few lables')
    for i, img in enumerate(img_lst):
        pylab.subplot(1, num_imgs, i+1)
        if bin_img: pylab.imshow(img, pylab.cm.gray)
        else : pylab.imshow(img)
        pylab.title(lbl_lst[i])
    pylab.rcParams['figure.figsize'] = (15, 6)
    pylab.show()


class BagClassifier(object):
    """
    Bag of words classifier class. Implements clustering using Kmeans
    
    ## Steps of the algorithm for the training phase
    + for each training item it will attempt to get its feature and form the KNN dataset
    + once all the features are collected, get the words or the representative of all of them
    + once all the words are done, for each image in the data-set we will attempt to calculate for which center does
      these descriptor belong
    + a data-set if former where features are number of occurence of each word [feature size = k] and label is its type
    + an SVM is built to further predict future classes
    
    ## Steps of the algorithm for the testing phase
    + get the descriptors of an image
    + use the kmeans to count the frequency of words in it
    + feed this data to the classifier
    
    ## Notes :
    + Descriptors are obtained using the "Oriented FAST and Rotated BRIEF method"
    """
    
    def __init__(self, dataset_dir, k=100, train_ext='.jpg'):
        """
        ## ِ Arguments:
        + dataset_dir : a dictionary with the path for each data-set and the class name of this path. E.g. 
        dataset_dir = {"/dataset/cars_train":"car"} means the directory for the class car is in the key
        + k : the total number of words
        + train_ext : the file extension for the training data items by default it is assumed to be an image
        with in a .jpg format
        """
        self.dataset_dir = dataset_dir
        self.num_features = k
        self.train_extension = train_ext
        self.descriptor_dataset = {class_name:[] for class_name in dataset_dir.values()}
        self.class_labels = {c:i for i,c in enumerate(dataset_dir.values())}
        self.orb = cv2.ORB_create()
        self.kmeans = KMeans(n_clusters=k)
        self.svm = svm.SVC(kernel='linear', C = 1.0)
        self.classifier_dataset = None
        self.dataset_length = 0
        self.normalized = None

    def train(self, samples_per_class = None):
        """
        Trains the classifier
        
        ## arguments
        + samples_per_class : the number of items to consider from the class directory [None for all]
        """        
        for _dir in self.dataset_dir:
            _sample = 0
            _internal_counter = 0
            for filename in os.listdir(_dir):
                if filename.endswith(self.train_extension):
                    img = read(_dir+'/'+filename)
                    key_pts = self.orb.detect(img)
                    descriptor = self.orb.compute(img, key_pts)[1]
                    self.descriptor_dataset[self.dataset_dir[_dir]].append(descriptor)
                    self.dataset_length += 1
                    #_internal_counter += 1*descriptor.shape[0]
                    if samples_per_class is not None and samples_per_class == _sample:
                        break
                    _sample += 1
                    
        # now all the words are collected
        self.kmeans = self.kmeans.fit(np.concatenate(np.concatenate(list(self.descriptor_dataset.values()))))
        # build the data-set with k features +1 for the label number
        self.classifier_dataset = np.zeros([self.dataset_length, self.num_features+1])
        #_c = 0
        _ii = 0
        for cl in self.descriptor_dataset.keys():
            for img_idx, img in enumerate(self.descriptor_dataset[cl]):
                u, c = np.unique(self.kmeans.predict(img), return_counts=True)
                self.classifier_dataset[img_idx+_ii, :-1][u] = c 
            self.classifier_dataset[_ii:_ii+len(self.descriptor_dataset[cl]), -1] = self.class_labels[cl]                    
            _ii += len(self.descriptor_dataset[cl])
        self.normalized = StandardScaler().fit(self.classifier_dataset[:, :-1])
        self.classifier_dataset[:, :-1] = self.normalized.transform(self.classifier_dataset[:, :-1])
        self.svm = self.svm.fit(self.classifier_dataset[:, :-1], self.classifier_dataset[:, -1])
        
    def predict(self, img, verbose=1):
        """
        Inference engine the method return
        
        ## arguments
        + img : np.array of 2D for the image to classify
        + verbose : verbosity level; currently [0 or 1] could be given, if 1 is given only the prediction is printed
        
        ## return
        + detected_class : a string for the actual detected class
        """
        key_pts = self.orb.detect(img)
        descriptor = self.orb.compute(img, key_pts)[1]
        feature_vector = np.zeros([self.num_features])
        u, c = np.unique(self.kmeans.predict(descriptor), return_counts=True)
        feature_vector[u] = c
        feature_vector = self.normalized.transform(feature_vector.reshape(1,-1))
        if(verbose == 1):
            print(self.svm.predict(feature_vector), self.class_labels)
        return self.svm.predict(feature_vector)


def save_model(obj, file_name):
    """
    exports the model for using later
    
    ## arguments
    + obj : the BagClassifier object
    + file_name : the model dump file name to be loaded later [INCLUDING THE EXTENSION]
    """
    joblib.dump((obj.svm,obj.kmeans, obj.num_features, obj.dataset_dir, obj.normalized), file_name, compress=3)
    
def load_model(model_name):
    """
    creats a model from the dump file containing the model parameters
    
    ## arguments
    + model_name : the dump file name [INCLUDING THE EXTENSION]
    
    ## returns
    + obj : the created BagClassifier object
    """
    
    _svm, _kmeans, _num_features, _dataset_dir, _normalized = joblib.load(model_name)
    obj = BagClassifier(_dataset_dir, _num_features)
    obj.svm = _svm
    obj.kmeans = _kmeans
    obj.normalized = _normalized
    return obj
