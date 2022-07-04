import socket
import datetime

HOST = "10.61.5.18"  
PORT = 80  
encoding = 'utf-8'

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
    dateTime = str(datetime.datetime.now())
    s.connect((HOST, PORT))
    s.sendall(dateTime.encode())
    data = s.recv(1024).decode(encoding)
    
print(data)
s.close()