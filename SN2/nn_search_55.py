import numpy as np
import random
import sys
import os
import time
from itertools import product,permutations

np.set_printoptions(threshold=sys.maxsize)
np.set_printoptions(linewidth=np.inf)
class Network:
    def __init__(self, arr, noise=0.1, method="hebb", asyncParm = 0, threshold = 0):
        self.arr = arr
        #self.neurons = neurons
        self.noise = noise
        self.method = method
        self.threshold = threshold # default 0
        self.weights = []
        self.asyncParm = asyncParm
        self.maxIterations = 2000
        self.asyncNumOfIterations = 40
    def trainNetwork(self):
        trainData = self.arr
        self.neurons = trainData.shape[1]
        self.weights = np.zeros((self.neurons, self.neurons))
        if(self.method == "hebb"):
            for u in range(len(trainData)):
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
        if self.asyncParm == 0:
            for it in range(self.maxIterations):
                s_temp = s.copy() 
                for i in range(len(s)):
                    calc = 0
                    for j in range(len(s)):
                        calc += self.weights[i][j]*s[j]
                    if(calc >= self.threshold):
                        s_temp[i] = 1
                    else:
                        s_temp[i] = -1
                s = s_temp
                energy_new = self.calculateEnergy(s)
                if(energy == energy_new): # covereged
                    return s
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
                energy = energy_new
        
        return s

    def testNetwork(self):
        testData_all = self.arr
        counter = 0
        for i in range(len(testData_all)):
            testData = np.copy(testData_all[i])
            results = self.RunSingleTest(testData)
            if(np.array_equal(testData, results)):
                counter = counter + 1
        return counter, testData_all
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

def random_product(*args, **kwds):
    "Random selection from itertools.product(*args, **kwds)"
    pools = map(tuple, args) * kwds.get('repeat', 1)
    return tuple(random.choice(pool) for pool in pools)

def random_permutation(iterable, r=None):
    "Random selection from itertools.permutations(iterable, r)"
    pool = tuple(iterable)
    r = len(pool) if r is None else r
    return tuple(random.sample(pool, r))

"""
start
"""
debug = 0

selectedFile = pathname = os.path.dirname(sys.argv[0]) + "/data/letters-14x20.csv"
noise = 0.0
method = "hebb"
asyncParm = 0

threshold = 0
counter = 0
best_sol = []
all_options = np.asarray([item for item in product([-1, 1], repeat=25)])
print("Product done, calculating...")
for i in range(200000000):
    idx = np.random.choice(all_options.shape[0], counter+1, replace=False)
    x = all_options[idx]
    myNetwork = Network(x, noise, method, asyncParm, threshold)
    myNetwork.trainNetwork()
    res = myNetwork.testNetwork()
    #print(res[0])
    if(res[0] > counter):
        counter = res[0]
        best_sol = res[1]
        print(counter)
        print(best_sol)
#for i in range(1, 25):
#    print('i' + str(i))
#    x = np.empty((i,25), dtype=int)
#    for comb in random_permutation(permutations(all_options, i)):
#        print(comb)
#        x.flat[:] = comb
#        #print(x)    
#        myNetwork = Network(x, noise, method, asyncParm, threshold)
#        myNetwork.trainNetwork()
#        res = myNetwork.testNetwork()
#        #print(res[0])
#        if(res[0] > counter):
#            i = i+1
#            counter = res[0]
#            best_sol = res[1]
#            print(counter)
#            print(best_sol)
#            break
#        #exit()