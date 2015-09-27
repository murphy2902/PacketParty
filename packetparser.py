# -*- coding: utf-8 -*-
"""
Created on Sat Sep 26 20:18:59 2015

@author: herzonflores
"""

import re
#import socket
#import os

# python file that when executed will read a file and regex out only the lines that we want that have Origin and Destination IPs with thier timestamps, an additionall column will be added to that row that will be the d/dt of the timestamps

# read in a file, that will have been made by tcp dump, get started with lines that have been gathered only after 20:30.

# 192.168.1.80

packetdata = open('modelpacketCapture.txt', 'r')
outputfile = open('mongoData', 'a')
for i in packetdata:
    matchObj = re.match(r'(\d\d:\d\d:\d\d).*(IP\s[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)\.(.*)\s>\s([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)', i)
    if matchObj is None:
        continue
    
    k = matchObj.group(1) + " , " + matchObj.group(3) + " , " + matchObj.group(2) + " , " + matchObj.group(4) + "\r\n"
    outputfile.write(k)
    