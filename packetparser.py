#!/usr/bin/env python
# -*- coding: utf-8 -*-
"""
Created on Sat Sep 26 20:18:59 2015

@author: herzonflores
"""

import re
import socket
import subprocess 
#import os

# python file that when executed will read a file and regex out only the lines that we want that have Origin and Destination IPs with thier timestamps, an additionall column will be added to that row that will be the d/dt of the timestamps

# read in a file, that will have been made by tcp dump, get started with lines that have been gathered only after 20:30.

# 192.168.1.80

def queryDNS(server,query):
    #Define a socket connection
    s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    s.connect((server,43))
    #Query the target server    
    argument = "'origin " + query + "'" + '\r\n'
    s.send(argument)
    
    msg_back = ''
    while len(msg_back) < 10000:
        chunk = s.recv(100)
        if(chunk == ''):
            break
        msg_back = msg_back + chunk
        
    return msg_back
   
'''
def parseTcpStream(result):
    matchObj = re.match(r'(\d\d:\d\d:\d\d).*(IP\s[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)\.(.*)\s>\s([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)', result)
    if matchObj is None:
        continue
    
    ShadowServerOrg = queryDNS('asn.shadowserver.org', matchObj.group(2)[3:])
    
    k = matchObj.group(1) + " , " + matchObj.group(3) + " , " + matchObj.group(2) + " , " + matchObj.group(4) + " , " + ShadowServerOrg + "\r\n"
    
    # write entry to mongoDB
'''

packetdata = open('modelpacketCapture.txt', 'r')
outputfile = open('mongoData', 'a')
for i in packetdata:
    matchObj = re.match(r'(\d\d:\d\d:\d\d).*(IP\s[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)\.(.*)\s>\s([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)', i)
    if matchObj is None:
        continue
    
    ShadowServerOrg = queryDNS('asn.shadowserver.org', matchObj.group(2)[3:])
    
    k = matchObj.group(1) + " , " + matchObj.group(3) + " , " + matchObj.group(2) + " , " + matchObj.group(4) + " , " + ShadowServerOrg + "\r\n"
    
    outputfile.write(k)


    
    