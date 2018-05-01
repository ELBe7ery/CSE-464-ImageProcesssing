"""
Image processing project

Group:
  + Eslam Mohamed
  + Yaman Qoudiematy
  + Omar abdelhakim
  + Abdelrahman Elbehery


Notes:
+ All the kernels used are odd an symmetric [3x3, 5x5, ....]
+ Helper functions are added here for readability
+ Some functions have their name changed for readability برضو

Dependencies:
+ numpy
+ opencv [cv2]
+ sklearn
+ matplotlib
+ keras
+ imageio
"""
import os
import cv2
import numpy as np
from imageio import imread, imwrite
from skimage.transform import resize
from keras.models import load_model


class FaceClassifier(object):
    """
    ## Abstract
    A face classification class that utilizes a Keras trained FaceNet model alongside a distance calculation against database
    of faces
    
    ## Steps using this class
    1. initiate a new mode, giving it the proper image database
    2. for each image to be added
        2.1. extract faces using OpenCv
        2.2. feed each face image to the trained model [inference stage]
        2.3. once an $R^{2}$ encoding vector is obtained we either do the clustering or a broadcasted
             distance calculation; such that the result of such a process will be the vectors with the closes distance
    3. obtain the images and the info of them and show them to the user
    """
    def __init__(self, database_dir="model/db.txt", img_ext='.jpg',
                 cascade_path='model/haarcascade_frontalface_alt2.xml', keras_model='model/facenet_keras.h5', 
                 write_face_dir="faces/", db_img_name="tayh_", database_info_dir="model/info.txt"):
        """
        ctor
        ## Arguments
        + database_dir : the file location for the database
        + img_ext : default image extension for trainng images
        + cascade_path : opencv classifier file
        + write_face_dir : write directory location
        + cascade_path : opencv cascade face detection file path
        + keras_model : FaceNet keras model
        """
        self.database = np.loadtxt(database_dir)
        self.database_info_dir = database_info_dir
        self.database_dir = database_dir
        self.img_ext = img_ext
        self.cascade = cv2.CascadeClassifier(cascade_path)
        self.model = load_model(keras_model)
        self.faces = []
        self.write_face_dir = write_face_dir
        self.db_name = db_img_name
        if write_face_dir[-1]!="/":
            self.write_face_dir += '/'
        with open(self.database_info_dir, 'rU') as in_file:
            self.database_info = in_file.read().split('\n')
    
    def prewhiten(self, x):
        """
        Facenet pre-processing required for the inputs
        """
        if x.ndim == 4:
            axis = (1, 2, 3)
            size = x[0].size
        elif x.ndim == 3:
            axis = (0, 1, 2)
            size = x.size
        else:
            raise ValueError('Dimension error')

        mean = np.mean(x, axis=axis, keepdims=True)
        std = np.std(x, axis=axis, keepdims=True)
        std_adj = np.maximum(std, 1.0/np.sqrt(size))
        y = (x - mean) / std_adj
        return y

    def l2_normalize(self, x, axis=-1, epsilon=1e-10):
        """
        Facenet pre-processing required for the inputs
        """
        output = x / np.sqrt(np.maximum(np.sum(np.square(x), axis=axis, keepdims=True), epsilon))
        return output

    def detect_faces(self, imname, margin=10, image_size=160, show_faces=True, dir_name=None):
        """
        Face detection algorithm using OpenCv
        ## Arguments
        + imname : inference image directory
        + margin : the margin from the returned face cordinates
        """
        try:
            img = imread(imname)
        except:
            return("Error03: No image found")
            #return
        faces = self.cascade.detectMultiScale(img, scaleFactor=1.1, minNeighbors=3)
        detected_faces = []
        for (x, y, w, h) in faces:
            cropped = img[y-margin//2:y+h+margin//2, x-margin//2:x+w+margin//2, :]
            aligned = resize(cropped, (image_size, image_size), mode='reflect')
            #show([aligned])
            aligned = self.prewhiten(aligned)
            detected_faces.append(np.array([aligned]))
        self.faces = detected_faces
        _c = 1
        if dir_name is None:
            dir_name = self.write_face_dir
            _c = 0
        if show_faces:
            #dir_name = self.write_face_dir
            [imwrite(dir_name+"face_"+str(i+self.database.reshape(-1, 128).shape[0]*_c)+self.img_ext,
                     self.faces[i][0]) for i in range(len(self.faces))]
    
    def add_to_db(self, img2add, lost_info, show_faces=True, dir_name="db/"):
        """
        Adds an image to the database by doing the following sequence of steps
        1. extract all the faces using opencv face detection algorithm
        2. given the image info; attach this info to the image in the database
        3. for each face, get the encoding vector and store it in the database

        ## Arguments
        + img2add: the image directory
        + lost_info: the string representing the image, so far we allow separating info with a simi-colon in this prototype
        """
        if lost_info[-1]!="\n":
            lost_info += "\n"
        self.detect_faces(img2add, show_faces=show_faces, dir_name=dir_name)
        if len(self.faces)==0:
            return("Error02: No faces available in your image; please insert another image\n")
            #return
        for face in self.faces:
            feat_vect = self.model.predict_on_batch(face)
            feat_vect = self.l2_normalize(feat_vect)
            if self.database.shape[0]!=0:
                self.database=np.vstack((self.database, feat_vect))
            else:
                self.database = feat_vect
            np.savetxt(self.database_dir, self.database)
            self.database_info.append(lost_info)
            for i in range(len(self.database_info)):
                if self.database_info[i][-1] !='\n':
                    self.database_info[i]+='\n'
            with open(self.database_info_dir, 'w') as out_file:
                out_file.write(''.join(self.database_info)+"\n")
        return "Added successfully to the DB"
                        
        
    
    def infer(self, imgname, add_to_db=True, show_faces=True):
        """
        Does the inference stage
        
        ## arguments
        + imgname : the image location on the user side
        + add_to_db : in case no matches found in the DB, the user will
        """
        os.system("cd faces&rm *.jpg")
        self.detect_faces(imgname, show_faces=show_faces)
        if len(self.faces)==0:
            return("Error01: No faces available in your image; please insert another image\n")
            #return
        ret = ""
        for face in self.faces:
            feat_vect = self.model.predict_on_batch(face)
            feat_vect = self.l2_normalize(feat_vect)
            dist = (self.database - feat_vect)**2
            dist = np.sum(dist, axis=1)
            same_faces = np.where(dist<1)
            for idx in same_faces[0]:
                ret+=("img:"+self.db_name+str(idx)+self.img_ext+" " + self.database_info[idx] + "\n")
        return ret
