/*
Ton Hoang Cam
23110186
*/
#include <iostream>
using namespace std;
int n;

void swap(int array[], int a, int b)
{
	int tempt;
	tempt = a;
	a = b;
	b = tempt;
}

void sapxep(int array[])
{
	int i, j;
	int right = n-1, left= 0, vitri = n -1;
	while (left < right)
	{
		for (j = right; j > left; j--)
		{
			if (array[j] < array[j - 1])
			{
				swap(array[j], array[j - 1]);
					vitri = j;
			}
		}
		right = vitri;
	}
}

int main()
{
	int array[1000];
	cin >> n;
	for (int i = 0; i < n; i++)
		cin >> array[i];

	sapxep(array);
	for (int i = 0; i < n; i++)
		cout << array[i] << " ";
	return 0;
}
