import numpy as np
import random
import sys
import os
import time
np.set_printoptions(threshold=sys.maxsize)
np.set_printoptions(linewidth=np.inf)
class Network:
    def __init__(self, selectedFile="small-7x7.csv", noise=0.1, method="hebb", asyncParm = 0, threshold = 0):
        self.file = selectedFile
        #self.neurons = neurons
        self.noise = noise
        self.method = method
        self.threshold = threshold # default 0
        self.weights = []
        self.asyncParm = asyncParm
        self.maxIterations = 2000
        self.asyncNumOfIterations = 40
    def trainNetwork(self):
        trainData = np.genfromtxt(self.file, delimiter=',')
        self.neurons = trainData.shape[1]
        self.weights = np.zeros((self.neurons, self.neurons))
        if(self.method == "hebb"):
            for u in range(len(trainData)):
                print(str(u))
                for i in range(self.neurons):
                    for j in range(self.neurons):
                        self.weights[i][j] += trainData[u][i]*trainData[u][j]
                    self.weights[i][j] = self.weights[i][j]/len(trainData)
            self.weights = self.weights - np.diag(np.diag(self.weights))
        else:
            for u in range(len(trainData)):
                print(str(u))
                for i in range(self.neurons):
                    for j in range(self.neurons):
                        self.weights[i][j] = self.weights[i][j] + (1/len(trainData))*trainData[u][j]*(trainData[u][i]-self.weights[i][j]*trainData[u][j])
            self.weights = self.weights - np.diag(np.diag(self.weights))
            

    def RunSingleTest(self, singleInput):
        energy = self.calculateEnergy(singleInput)
        s = singleInput
        print(s)
        time.sleep(1)
        if self.asyncParm == 0:
            for it in range(self.maxIterations):
                for i in range(len(s)):
                    calc = 0
                    for j in range(len(s)):
                        calc += self.weights[i][j]*s[j]
                    if(calc >= self.threshold):
                        s[i] = 1
                    else:
                        s[i] = -1
                energy_new = self.calculateEnergy(s)
                if(energy == energy_new): # covereged
                    print(1.0)
                    return s
                print(s)
                time.sleep(1)
                energy = energy_new
        else:
            for it in range(self.maxIterations):
                for iterator2 in range(self.asyncNumOfIterations):
                    i = np.random.randint(0, self.neurons) 
                    calc = 0
                    for j in range(len(s)):
                        calc += self.weights[i][j]*s[j]
                    if(calc >= self.threshold):
                        s[i] = 1
                    else:
                        s[i] = -1
                energy_new = self.calculateEnergy(s)
                if(energy == energy_new): # covereged
                    print(1.0)
                    return s
                print(s)
                time.sleep(1)
                energy = energy_new
        return s

    def testNetwork(self):
        testData_all = np.genfromtxt(self.file, delimiter=',')
        randomPick = random.randint(0, len(testData_all)-1)
        testData = np.copy(testData_all[randomPick])
        print(testData)
        indices = np.random.choice(np.arange(testData.size), replace=False,
                           size=int(testData.size * self.noise))
        testData[indices] *= -1
        results = self.RunSingleTest(testData)
        #print(results)
        #cov = testData_all[randomPick]-results
        #cov = cov[cov==0]
        #print(str(len(cov)/len(testData_all[0])))

    def calculateEnergy(self, s):
        energy = 0
        for i in range(self.neurons):
            for j in range(self.neurons):
                energy += self.weights[i][j]*s[i]*s[j]
        energy = energy * (-0.5)
        for i in range(self.neurons):
            energy += s[i]*self.threshold
        return energy



"""
start
"""
debug = 0

if(debug == 0):
    selectedFile = sys.argv[1]
    noise = float(sys.argv[2])
    method = sys.argv[3]
    asyncParm = int(sys.argv[4])
else:
    selectedFile = pathname = os.path.dirname(sys.argv[0]) + "/data/letters-14x20.csv"
    noise = 0.5
    method = "hebb"
    asyncParm = 0
threshold = 0
myNetwork = Network(selectedFile, noise, method, asyncParm, threshold)
myNetwork.trainNetwork()
myNetwork.testNetwork()