import numpy as np
import matplotlib.pyplot as plt

x1 = np.linspace(-3 * np.pi, 0, 500)
x2 = np.linspace(0, 3 * np.pi, 500)

y1 = 1.5 * np.sin(x1)
y2 = 1.5 * np.sin(x2)

theta = np.linspace(0, 2 * np.pi, 500)
r = 2 + np.cos(10 * theta) + 2 * np.sin(5 * theta)

plt.figure(figsize=(10, 6))

plt.plot(x1, y1, 'r--', label=r'$y = 1.5\sin(x)$ with $x$ in $[-3\pi, 0]$')

plt.plot(r * np.cos(theta), r * np.sin(theta), 'g-', label=r'$r = 2 + \cos(10\theta) + 2\sin(5\ theta)$')

plt.plot(x2, y2, 'b:', label=r'$y = 1.5\sin(x)$ with $x$ in $[0, 3\pi]$')


plt.grid(True, linestyle='--', alpha=0.6)
plt.legend(loc='upper center')
plt.title('Combined Plot of Trigonometric and Polar Functions')
plt.xlabel('x')
plt.ylabel('y')

plt.axis('equal')

plt.show()