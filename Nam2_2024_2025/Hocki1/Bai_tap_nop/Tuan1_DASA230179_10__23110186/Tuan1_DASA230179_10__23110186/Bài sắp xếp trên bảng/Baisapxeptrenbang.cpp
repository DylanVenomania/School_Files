#include <iostream>
using namespace std;

void swap(int array[], int a, int b)
{
    int tempt;
    tempt = a;
    a = b;
    b = tempt;
}


void sapxepgiam(int array[], int n) 
{
    for (int i = 0; i < n - 1; i++) 
    {
        int max_index = i;
        for (int j = i + 1; j < n; j++) 
        {
            if (array[j] > array[max_index]) 
            {
                max_index = j;
            }
        }
        int temp = array[max_index];
        array[max_index] = array[i];
        array[i] = temp;
    }
}


void sapxeptang(int array[], int n) 
{
    for (int i = 0; i < n - 1; i++) 
    {
        int min_index = i;
        for (int j = i + 1; j < n; j++)
        {
            if (array[j] < array[min_index])
            {
                min_index = j;
            }
        }
        int temp = array[min_index];
        array[min_index] = array[i];
        array[i] = temp;
    }
}

int main() 
{
    int array[1000];
    int n;
    cin >> n;
    for (int i = 0; i < n; i++) 
        cin >> array[i];

    int duong[1000], am[1000], khong[1000];
    int duongCount = 0, amCount = 0, khongCount = 0;

    for (int i = 0; i < n; i++) 
    {
        if (array[i] > 0) 
            duong[duongCount++] = array[i];
        else if (array[i] < 0) 
            am[amCount++] = array[i];
        else 
            khong[khongCount++] = array[i];
    }

    sapxepgiam(duong, duongCount);
    sapxeptang(am, amCount);
    int index = 0;
    for (int i = 0; i < duongCount; i++) 
        array[index++] = duong[i];
    for (int i = 0; i < khongCount; i++) 
        array[index++] = khong[i];
    for (int i = 0; i < amCount; i++) 
        array[index++] = am[i];

    for (int i = 0; i < n; i++) 
        cout << array[i] << " ";
    return 0;
}