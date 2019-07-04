import cv2
# from PIL import Image
import sys
# import pylab
# from scipy import ndimage
import numpy as np
import matplotlib.pyplot as plt
# import matplotlib.cm as cm
# get silkworm eggs count

def get_count(path):
        img = cv2.imread(path)
        gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
        kernel = np.ones((11,11), np.uint8)
        tophat = cv2.morphologyEx(gray, cv2.MORPH_TOPHAT, kernel)
        # cv2.imshow("Tophat", tophat)
        # cv2.waitKey()
        ret, thresh = cv2.threshold(tophat,0,255,cv2.THRESH_BINARY_INV+cv2.THRESH_OTSU)
        # cv2.imshow("th2", thresh)
        # cv2.waitKey()
        dst = cv2.fastNlMeansDenoising(thresh,None,9,11)
        # cv2.imshow("denoised", dst)
        # cv2.waitKey()

        dst_color = cv2.cvtColor(dst, cv2.COLOR_GRAY2RGB)
        contours, hierarchy = cv2.findContours(dst, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
        # cv2.drawContours(dst_color, contours, -1, (0,0,255), 1)
        # cv2.imshow("contours", dst_color)
        # cv2.waitKey()
        #print("Found {} eggs".format(len(contours)))

        contour_list = []
        for contour in contours:
                approx = cv2.approxPolyDP(contour,0.01*cv2.arcLength(contour,True),True)
                area = cv2.contourArea(contour)
                if ((len(approx) > 1) & (area > 0.5 )):
                        contour_list.append(contour)

        cv2.drawContours(dst_color, contour_list, -1, (0,255,0), 1)
        cv2.imshow("contours", dst_color)
        cv2.waitKey()
        print(len(contour_list)) # -1 for window

def main():
    if len(sys.argv) >= 1:
        get_count(sys.argv[1])


if __name__ == "__main__":
    main()