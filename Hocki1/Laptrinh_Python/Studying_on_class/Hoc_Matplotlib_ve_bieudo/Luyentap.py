from matplotlib import pyplot as plt
import numpy as np

#x = np.array( [2, 7, 100, 1])
#y = np.array( [1, 9, 9, 2])

#plt.plot(x, y, 'mx:')
#plt.show()


x = np.arange(-4, 3, 0.1)
y = 3*x**2 + 4*x + 9

plt.plot(x, y, 'm--')

theta = np.arange(0, 4*np.pi, 0.1)
r = 0.5 *np.pi
x = r*np.cos(theta)
y = r*np.sin(theta)

plt.plot(x,y)



fig = plt.figure()
ax = fig.add_axes([0, 0, 1, 1])   #2 chỉ số đầu là left và bottom, 2 chỉ số sau là chiều rộng và chiều cao
ax.axis('equal')
langs = ['C', 'C++', 'Java', 'Python' , 'PHP']
students = [23, 17, 35, 29, 12]

ax.pie( students, labels = langs, autopct = '%1.2f%%')

plt.show()