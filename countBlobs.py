import cv2
import pylab
from scipy import ndimage

im = cv2.imread('image2.jpg')
# pylab.figure(0)
# pylab.imshow(im)

gray = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
gray = cv2.GaussianBlur(gray, (5,5), 0)
maxValue = 255
adaptiveMethod = cv2.ADAPTIVE_THRESH_GAUSSIAN_C#cv2.ADAPTIVE_THRESH_GAUSSIAN_C #cv2.ADAPTIVE_THRESH_GAUSSIAN_C
thresholdType = cv2.THRESH_BINARY#cv2.THRESH_BINARY #cv2.THRESH_BINARY_INV
blockSize = 9 #odd number like 3,5,7,9,11
C = -3 # constant to be subtracted
im_thresholded = cv2.adaptiveThreshold(gray, maxValue, adaptiveMethod, thresholdType, blockSize, C) 
# n_centers = cv2.connectedComponents(im_thresholded)[0] - 1
# print(n_centers)
labelarray, particle_count = ndimage.measurements.label(im_thresholded)
print(particle_count)
pylab.figure(1)
pylab.imshow(im_thresholded)
pylab.show()
# import cv2
# im = cv2.imread('image2.jpg')
# hsv = cv2.cvtColor(im, cv2.COLOR_BGR2HSV)
# th, bw = cv2.threshold(hsv[:, :, 2], 0, 255, cv2.THRESH_BINARY | cv2.THRESH_OTSU)
# kernel = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (3, 3))
# morph = cv2.morphologyEx(bw, cv2.MORPH_CLOSE, kernel)
# dist = cv2.distanceTransform(morph, cv2.DIST_L2, cv2.DIST_MASK_PRECISE)
# borderSize = 75
# distborder = cv2.copyMakeBorder(dist, borderSize, borderSize, borderSize, borderSize, 
#                                 cv2.BORDER_CONSTANT | cv2.BORDER_ISOLATED, 0)
# gap = 10                                
# kernel2 = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (2*(borderSize-gap)+1, 2*(borderSize-gap)+1))
# kernel2 = cv2.copyMakeBorder(kernel2, gap, gap, gap, gap, 
#                                 cv2.BORDER_CONSTANT | cv2.BORDER_ISOLATED, 0)
# distTempl = cv2.distanceTransform(kernel2, cv2.DIST_L2, cv2.DIST_MASK_PRECISE)
# nxcor = cv2.matchTemplate(distborder, distTempl, cv2.TM_CCOEFF_NORMED)
# mn, mx, _, _ = cv2.minMaxLoc(nxcor)
# th, peaks = cv2.threshold(nxcor, mx*0.5, 255, cv2.THRESH_BINARY)
# peaks8u = cv2.convertScaleAbs(peaks)
# contours, hierarchy = cv2.findContours(peaks8u, cv2.RETR_CCOMP, cv2.CHAIN_APPROX_SIMPLE)
# peaks8u = cv2.convertScaleAbs(peaks)    # to use as mask
# for i in range(len(contours)):
#     x, y, w, h = cv2.boundingRect(contours[i])
#     _, mx, _, mxloc = cv2.minMaxLoc(dist[y:y+h, x:x+w], peaks8u[y:y+h, x:x+w])
#     cv2.circle(im, (int(mxloc[0]+x), int(mxloc[1]+y)), int(mx), (255, 0, 0), 2)
#     cv2.rectangle(im, (x, y), (x+w, y+h), (0, 255, 255), 2)
#     cv2.drawContours(im, contours, i, (0, 0, 255), 2)

# cv2.imshow('circles', im)
# cv2.waitKey(0)
# cv2.destroyAllWindows()

# import cv2
# import numpy as np

# img = cv2.imread('image2.jpg', 0)
# seed_pt = (184,252)
# fill_color = 50
# mask = np.zeros_like(img)
# kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))
# for th in range(60, 120):
#     prev_mask = mask.copy()
#     mask = cv2.threshold(img, th, 255, cv2.THRESH_BINARY)[1]
#     mask = cv2.floodFill(mask, None, seed_pt, fill_color)[1]
#     mask = cv2.bitwise_or(mask, prev_mask)
#     mask = cv2.morphologyEx(mask, cv2.MORPH_OPEN, kernel)
# cv2.imshow('image',mask)
# cv2.waitKey(0)
# cv2.destroyAllWindows()



# n_centers = cv2.connectedComponents(mask)[0] - 1
# print('There are %d cells in the image.'%n_centers)

# import cv2
# import numpy as np;
# from matplotlib import pyplot as plt

# # Read image
# im = cv2.imread("eggs2.jpg")

# # Setup SimpleBlobDetector parameters.
# params = cv2.SimpleBlobDetector_Params()

# # Change thresholds
# params.minThreshold = 10
# params.maxThreshold = 200

# # Filter by Area.
# params.filterByArea = True
# params.minArea = 15

# # Filter by Circularity
# params.filterByCircularity = True
# params.minCircularity = 0.1

# # Filter by Convexity
# params.filterByConvexity = True
# params.minConvexity = 0.87

# # Filter by Inertia
# params.filterByInertia = True
# params.minInertiaRatio = 0.01

# # Create a detector with the parameters
# detector = cv2.SimpleBlobDetector_create(params)

# # Detect blobs.
# keypoints = detector.detect(im)

# # Draw detected blobs as red circles.
# # cv2.DRAW_MATCHES_FLAGS_DRAW_RICH_KEYPOINTS ensures
# # the size of the circle corresponds to the size of blob

# im_with_keypoints = cv2.drawKeypoints(im, keypoints, np.array([]), (255,0,0), cv2.DRAW_MATCHES_FLAGS_DRAW_RICH_KEYPOINTS)

# titles = ['Blobs Detected']
# images = [im_with_keypoints]


# for i in range(1):    
#     plt.subplot(1,1,i+1), plt.imshow(images[i],'gray')
#     plt.title(titles[i])
#     plt.xticks([]), plt.yticks([])  # to hide tick values on X and Y axis    
# plt.show()
# import cv2
# gray = cv2.imread("image3.jpg", cv2.IMREAD_GRAYSCALE)
# cv2.imshow("img1", gray)
# # gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# ## threshold
# th, threshed = cv2.threshold(gray, 100, 255,cv2.THRESH_BINARY+cv2.THRESH_OTSU)
# cv2.imshow("img", threshed)
# cv2.waitKey(0)
# cv2.destroyAllWindows()

# # findcontours
# cnts = cv2.findContours(threshed, cv2.RETR_LIST, cv2.CHAIN_APPROX_NONE)[-2]


# ## filter by area
# s1= 1
# s2 = 30
# xcnts = []
# for cnt in cnts:
#     if s1<cv2.contourArea(cnt) <s2:
#         xcnts.append(cnt)

# print("Dots number: {}".format(len(xcnts)))
# Dots number: 23

# import numpy as np
# from matplotlib import pyplot as plt
# from matplotlib import image as img
# # from IPython.html.widgets import interact, fixed
# plt.rcParams['figure.figsize'] = (10.0, 8.0) # 10 x 8 inches
# plt.gray()

# dna = img.imread('eggs1.png')
# print(dna.shape)
# dna = dna.max(axis=2)
# print(dna.shape)
# # plt.imshow(dna)

# T_otsu = mh.otsu(dna)
# print(T_otsu)
# plt.imshow(dna > T_otsu)

# # T_mean = dna.mean()
# # print(T_mean)
# # plt.imshow(dna > T_mean)

# plt.show()

# import scipy
# from scipy import ndimage
# import scipy.misc.imread
# import matplotlib.pyplot as plt

# #flatten to make greyscale, using your second red-black image as input.
# im = scipy.misc.imread('eggs1.png',flatten=1)
# #smooth and threshold as image has compression artifacts (jpg)
# im = ndimage.gaussian_filter(im, 2)
# im[im<10]=0
# blobs, number_of_blobs = ndimage.label(im)
# print('Number of blobls:', number_of_blobs)

# plt.imshow(blobs)
# plt.show()

