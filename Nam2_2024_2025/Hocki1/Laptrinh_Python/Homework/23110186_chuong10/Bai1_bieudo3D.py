import numpy as np
import matplotlib.pyplot as plt

def polynomial(x):
    return 3 * x**5 + 20 * x**4 - 10 * x**3 - 240 * x**2 -250 * x +200

x = np.linspace(-6, 4, 500)

y = polynomial(x)

plt.figure(figsize=(8, 6))
plt.plot(x, y, 'r--', linewidth=2) 

plt.xlabel('x')
plt.ylabel('y')
plt.title('Fifth Degree Polynomial')
plt.xlim(-6, 4)
plt.ylim(-1200, 400)

plt.grid(True, linestyle='--', alpha=0.6)

plt.show()