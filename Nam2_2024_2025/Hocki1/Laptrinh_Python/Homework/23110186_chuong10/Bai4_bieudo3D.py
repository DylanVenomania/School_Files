import numpy as np
import matplotlib.pyplot as plt

data = np.random.randn(1000)

plt.figure(figsize=(8, 6))
plt.hist(data, bins=30, color='skyblue', edgecolor='black', alpha=0.7)

plt.title('Ví dụ biểu đồ Histogram')
plt.xlabel('Phạm vi giá trị')
plt.ylabel('Tần suất')

plt.grid(axis='y', linestyle='--', alpha=0.7)

plt.show()