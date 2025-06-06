int[] ds;
int soluongphantu = 100;
int delaytime = 10;
String ten_thuat_toan = "";

void sinhmangngaunhien()
{
  for (int i = 0; i < ds.length; i++)
  {
    ds[i] = int(random(height) );
  }
}

void hienthimang()
{
  for(int i =0; i< ds.length; i++)
  {
    stroke(0);
    fill(0,0,250);
    rect(i*(width/ ds.length), height - ds[i], width/ds.length, ds[i] );
  }
}

void setup()
{
  size(800, 400);
  ds = new int[soluongphantu];
  sinhmangngaunhien();
  textSize(16);
}

void draw()
{
  background(255);
  hienthimang();
  
  fill(0);
  
  text("Nhấn phím '1' để sắp xếp theo kiểu Selection Sort", 20, 20);
  text("Nhấn phím '2' để sắp xếp theo kiểu Insertion Sort", 20, 40);
  text("Nhấn phím '3' để sắp xếp theo kiểu Bubble Sort", 20, 60);
  text("Nhấn phím '4' để sắp xếp theo kiểu Quick Sort", 20, 80);
  text("Nhấn phím '5' để sắp xếp theo kiểu Shake Sort", 20, 100);
  text("Bạn đã chọn thuật toán: " + ten_thuat_toan, 20, 140);
}


void keyPressed() 
{
  if (key == '1') 
  {
    ten_thuat_toan = "Selection Sort";
    new Thread(() -> selection_sort(ds, ds.length)).start();
  } 
  else if (key == '2') 
  {
    ten_thuat_toan = "Insertion Sort";
    new Thread(() -> insertion_sort(ds, ds.length)).start();
  } 
  else if (key == '3') 
  {
    ten_thuat_toan = "Bubble Sort";
    new Thread(() -> bubble_sort(ds, ds.length)).start();
  } 
  else if (key == '4') 
  {
    ten_thuat_toan = "Quick Sort";
    new Thread(() -> quick_sort(ds, 0, ds.length - 1)).start();
  } 
  else if (key == '5') 
  {
    ten_thuat_toan = "Shake Sort";
    new Thread(() -> shake_sort(ds, ds.length)).start();
  }
}

boolean sosanh(int a, int b)
{
  return a>b;
}

void swap(int[] ds, int i, int j  )
{
  int temp = ds[i];
  ds[i] = ds[j];
  ds[j] = temp;
  redraw();
  delay(delaytime);
}

void selection_sort(int[] ds, int n) 
{
  for (int i = 0; i < n - 1; i++) 
  {
    int min_index = i;
    for (int j = i + 1; j < n; j++) 
    {
      if (sosanh(ds[min_index], ds[j])) 
      {
        min_index = j;
      }
    }
    if (sosanh(ds[i], ds[min_index])) 
    {
      swap(ds, i, min_index);
    }
  }
}

void insertion_sort(int[] ds, int n) 
{
  for (int i = 1; i < n; i++) 
  {
    int key = ds[i];
    int j = i - 1;
    while (j >= 0 && sosanh(ds[j], key)) 
    {
      ds[j + 1] = ds[j];
      j--;
    }
    ds[j + 1] = key;
    redraw();
    delay(delaytime);
  }
}

void bubble_sort(int[] ds, int n) 
{
  for (int i = 0; i < n - 1; i++)
 {
    for (int j = 0; j < n - 1 - i; j++) 
    {
      if (sosanh(ds[j], ds[j + 1])) 
      {
        swap(ds, j, j+1);
      }
    }
  }
}

void shake_sort(int[] ds, int n) {
  boolean swapped = true;
  int start = 0;
  int end = n - 1;

  while (swapped) 
  {
    swapped = false;
    for (int i = start; i < end; i++)
    {
      if (sosanh(ds[i], ds[i + 1])) 
      {
        swap(ds, i, i + 1);
        swapped = true;
      }
    }
    if (!swapped) break;
    swapped = false;
    end--;
    for (int i = end; i > start; i--) 
    {
      if (sosanh(ds[i - 1], ds[i]))
      {
        swap(ds, i - 1, i);
        swapped = true;
      }
    }
    start++;
  }
}

int partition(int[] ds, int l, int r) 
{
  int pivot = ds[(l + r) / 2];
  int i = l;
  int j = r;
  while (i <= j) 
  {
    while (sosanh(pivot, ds[i])) i++;
    while (sosanh(ds[j], pivot)) j--;
    if (i <= j) 
    {
      swap(ds, i, j);
      i++;
      j--;
    }
  }
  return i;
}

void quick_sort(int[] ds, int l, int r) 
{
  if (l < r) 
  {
    int p = partition(ds, l, r);
    quick_sort(ds, l, p - 1);
    quick_sort(ds, p, r);
  }
}
