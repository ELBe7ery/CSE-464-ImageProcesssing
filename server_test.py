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
+ PYTHON MUST BE INSTALLED AND ADDED TO YOUR PATH; VERSION: 3.x; VARIABLE NAME: python3

Dependencies:
+ numpy
+ opencv [cv2]
+ sklearn
+ matplotlib
+ keras
+ imageio

"""
import socket
from FaceClassifier import FaceClassifier


TCP_IP = '127.0.0.1'
TCP_PORT = 5005
BUFFER_SIZE = 1024

try:
    print("Loading model")
    clf = FaceClassifier()
    print("Model created successfully")
except:
    print("failed to load model")

def helper_add_db(clf, img_dir, info):
    """
    Attempts to insert an image into the database
    """
    return clf.add_to_db(img_dir, info)

def helper_infer(clf, img_dir):
    """
    Attempts to insert an image into the database
    """
    return clf.infer(img_dir)

while 1:
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    s.bind((TCP_IP, TCP_PORT))
    s.listen(1) 
    conn, addr = s.accept()
   
    data = conn.recv(BUFFER_SIZE).decode()
    cmd = data.split("\n")
    if cmd[0] == "add":
        r = helper_add_db(clf, cmd[1], cmd[2])
        conn.send(r.encode())
    elif cmd[0] == "infer":
        r = helper_infer(clf, cmd[1])
        if r=="":
            conn.send("Face not found in our database".encode())
        else:
            conn.send(r.encode())
    elif cmd[0]=="echo":
        print("client connected")
        conn.send("Server is running".encode())
    else:
        conn.send("An error occurred".encode())  # echo
conn.close()
