#include <iostream>
#include "Array.h"

using namespace std;

template<class T>
Array<T>::Array(int _size){
    this->size = _size;
    this->data = new int[_size];
    currentIndex =0;
}

template<class T>
Array<T>::Array(Array<T> &right) {
    size = right.size;
    data = new int[size];
    currentIndex = 0;
    for (int i = 0; i < size; i++) {
        data[i] = right.data[i];
}
}

template<class T>
Array<T>::~Array(){
    delete []data;
}

template<class T>
void Array<T>::expandArray()
{
    int newSize = size * 1.5;
    T* NewArray = new T[newSize];
    for (int i = 0; i < size; i++){
        NewArray[i] = data[i];
    }

    delete[] data;
    data = NewArray;
    size *= 1.5;
}

template<class T>
void Array<T>::fill() {
    int item;
    cout << "How Many Items Do you want to fill? " << endl;
    cin >> item;
    if (item >= size){
        expandArray();
    }
    for (int i = 0; i < item; i++){
        cout << "Enter item of index: " << i << endl;
        cin >> data[i];
        currentIndex++;
    }
};

template<class T>
void Array<T>::display()
{
    cout << "Display Array Items: " << endl;
    cout << endl;
    for (int i = 0; i < currentIndex; i++){
        cout << "Value of index: " << i << " = " << data[i] << endl;
    }
    cout << endl;
}

template<class T>
void Array<T>::push(T item)
{
    //Expand the Array
    if (currentIndex == size){
        expandArray();
    }
    data[currentIndex] = item;
    currentIndex++;
}

template<class T>
void Array<T>::insert(T item, int location)
{
    if (location >= 0 && location <= this->Size)
    {
        for (int i = this->CurrentIndex; i > location; i--)
        {
            data[i] = data[i - 1];
        }
        data[location] = item;
        currentIndex++;
    }
}

template<class T>
void Array<T>::deletee(int location){
    if (location >= 0 && location <= this->Size){
        for (int i = location; i <= this->CurrentIndex; i++)
        {
            data[i] = data[i + 1];
        }
        currentIndex--;
    }
    else{
        //cout << "Out of range" << endl;
    }
}

template<class T>
T Array<T>::find(T item){
    for (int i = 0; i < currentIndex; i++){
        if (this->data[i] == item){
            return i;
            break;
        }
    }
}

template<class T>
T Array<T>::getSize(){
    return size;
}

template<class T>
T Array<T>::getCount(){
    return currentIndex;
}

template<class T>
Array<int&> Array<T>::operator[](int index){
if (index <= currentIndex && index >= 0)

return data[index];

}

template<class T>
const Array<T> Array<T>::operator=(const Array<T> &right){
    if(this != &right){
        delete []data;
        size = right.size;
        currentIndex = right.currentIndex;
        data = new T[size];
        for (int i = 0; i < size; i++) {
            data[i] = right.data[i];
        }
    }
    return *this;
};

template<class T>
const Array<T> Array<T>::operator+(const Array<T> &right){
    int minSize = min(currentIndex, right.currentIndex);
    Array<T> temp(minSize);
    for(int i = 0 ; i < minSize ; i++){
        temp.push(data[i] + right.data[i]);
    }
    return temp;
}

int main() {
    Array<int> arr(10);
    Array<int> arr2(10);
    Array<int> arr3(30);
    arr.push(10);
    arr.push(20);
    arr.push(30);
    arr.push(40);
    arr2.push(50);
    arr2.push(60);
    arr2.push(70);
    arr2.push(80);

    arr3 = (arr + arr2);
    arr3.display();
    return 0;
}
