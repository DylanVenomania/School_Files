import numpy as np
import matplotlib.pyplot as plt

categories = ['A', 'B', 'C', 'D', 'E']
values = [10, 15, 7, 25, 18]  

plt.figure(figsize=(8, 6))
plt.bar(categories, values, color='skyblue', edgecolor='black')

plt.title('Example Bar Chart')
plt.xlabel('Categories')
plt.ylabel('Values')

for i, value in enumerate(values):
    plt.text(i, value + 0.5, str(value), ha='center')


plt.grid(axis='y', linestyle='--', alpha=0.7)

plt.show()