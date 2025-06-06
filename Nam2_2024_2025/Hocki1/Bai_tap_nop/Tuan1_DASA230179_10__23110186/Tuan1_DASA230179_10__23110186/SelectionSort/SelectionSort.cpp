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
	int min;
	for (int i = 0; i < n - 1; i++)
	{
		min = i;
		for (int j = min + 1; j < n; j++)
		{
			if (array[j] < array[min])
				min = j;
		}
		swap(array[i], array[min]);
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

