import socket
import datetime
import json

HOST = "10.61.5.18"  
PORT = 80  
encoding = 'utf-8'


"""
with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    dateTime = str(datetime.datetime.now())
    s.connect((HOST, PORT))
    s.sendall(dateTime.encode())
    data = s.recv(1024).decode(encoding)
"""
data = '{"modelName":"RW1", "x":2.60, "y":-2.85, "z":-40.02, "rx":0.04, "ry":359.61, "rz":178.97, "score":0.50, "dateTime":"05/07/2565 10:01 AM"}'

data1 = '{"modelName":"None", "x":0.0, "y":0.0, "z":0.0, "rx":0.0, "ry":0.0, "rz":0.0, "score":0.0, "dateTime":"05/07/2565 10:01 AM"}'

data_dict = json.loads(data)

print(data_dict["x"])
print(type(data_dict["x"]))
#s.close()