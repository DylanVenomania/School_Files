import numpy as np
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D

x = np.linspace(-5, 5, 100)
y = np.linspace(-5, 5, 100)
x, y = np.meshgrid(x, y)

z_squared = 1 + 0.3 * x**2 + 0.3 * y**2
z_positive = np.sqrt(z_squared)
z_negative = -np.sqrt(z_squared)

fig = plt.figure(figsize=(10, 7))
ax = fig.add_subplot(111, projection='3d')

surf1 = ax.plot_surface(x, y, z_positive, cmap='jet', vmin=-5, vmax=5, alpha=0.8)
surf2 = ax.plot_surface(x, y, z_negative, cmap='jet', vmin=-5, vmax=5, alpha=0.8)

cbar = fig.colorbar(surf1, ax=ax, shrink=0.5, aspect=10)
cbar.set_label('f(x, y)', fontsize=12)

ax.set_title('Biểu đồ Hyperboloid')
ax.set_xlabel('x')
ax.set_ylabel('y')
ax.set_zlabel('f(x, y)')

plt.show()