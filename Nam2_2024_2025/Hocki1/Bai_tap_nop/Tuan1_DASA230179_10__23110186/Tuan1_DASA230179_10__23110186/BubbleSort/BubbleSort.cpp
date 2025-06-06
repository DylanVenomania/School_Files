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
	for (int i = 0; i < n - 1; i++)
	{
		int j = n - 1;
		while (j > i)
		{
			if (array[j] < array[j - 1])
				swap(array[j], array[j - 1]);
			j--;
		}
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
