import numpy as np
import imageio
import sys
#np.set_printoptions(threshold=sys.maxsize)
#np.set_printoptions(linewidth=np.inf)
imgs = np.empty((0,150*150), int)
for i in range(1, 10):
    img = (imageio.imread("C:/Users/Mateusz/Desktop/kittens/"+str(i)+".bmp", as_gray=True))/255
    img[img < 1] = 0
    img[img == 1] = -1
    img[img == 0] = 1

    img = img.flatten()
    imgs = np.vstack((imgs, img))
    #print(imgs)
    #img = list(img)
#print(imgs)
#np.savetxt("image.csv",imgs, delimiter=",", fmt='%i')