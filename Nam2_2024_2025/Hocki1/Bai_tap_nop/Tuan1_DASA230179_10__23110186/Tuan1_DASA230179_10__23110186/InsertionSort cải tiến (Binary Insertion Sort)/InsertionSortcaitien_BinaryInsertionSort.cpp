/*
Ton Hoang Cam
23110186
*/
#include <iostream>
using namespace std;
int n;

int vitrichen(int array[], int giatri, int left, int right) 
{
    while (left < right) 
    {
        int mid = (left + right) / 2;
        if (array[mid] < giatri) 
        {
            left = mid + 1;
        }
        else 
            right = mid;
    }
    return left;
}

void sapxep(int array[], int n) 
{
    for (int i = 1; i < n; i++) 
    {
        int giatri = array[i];
        int vitri = vitrichen(array, giatri, 0, i);
        for (int j = i; j > vitri; j--) 
            array[j] = array[j - 1];
        array[vitri] = giatri;
    }
}

int main() {
    int array[1000];
    cin >> n;
    for (int i = 0; i < n; i++)
        cin >> array[i];

    sapxep(array, n);

    for (int i = 0; i < n; i++) 
        cout << array[i] << " ";
    return 0;
}