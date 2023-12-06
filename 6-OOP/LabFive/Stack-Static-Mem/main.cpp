#include <iostream>
#include "Stack.h"
using namespace std;

template<class T>
Stack<T>::Stack()
{
    this->initial_size = 5;
    this->current_size = initial_size;
    this->top = -1;
    this->data = new T[initial_size];
    objCount++;
}

template<class T>
Stack<T>::Stack(int size) {
    this->initial_size = size;
    this->current_size = initial_size;
    this->top = -1;
    this->data = new T[size];
    objCount++;
}

template<class T>
Stack<T>::Stack(Stack &S)
{
    top = S.top;
    initial_size = S.initial_size;
    current_size = S.current_size;
    data = new T [initial_size];
    for(int i = 0 ; i <= top ; i++)
    {
        data[i] = S.data[i];
    }
}

template<class T>
Stack<T>::~Stack()
{
    for(int i = 0 ; i < top ; i++)
        data[i] = -1;
    delete []this->data;
    objCount--;
}

template<class T>
void Stack<T>::resize()
{
    if(this->top < this->current_size - 1) return;

    int newSize = this->current_size * 1.5;
    T *newArr = new T [newSize];
    std:copy(this->data, this->data + this->current_size, newArr);
    this->current_size *= 1.5;

    delete[] this->data;
    this->data = newArr;
}

template<class T>
void Stack<T>::push(T item)
{
    this->resize();
    this->data[++this->top] = item;
}

template<class T>
int  Stack<T>::peek()
{
    if (this->top == -1)  return 0;
    return this->data[this->top];
}

template<class T>
int Stack<T>::pop()
{
    if (this->top == -1)
        return 0;
    else{
        int head_data = this->data[this->top];
        this->data[this->top] = 0;
        this->top--;
        return head_data;
    }
}

template<class T>
bool Stack<T>::isEmpty()
{
    if (this->top == -1) return true;
    else return false;
}

template<class T>
int Stack<T>::size()
{
    return this->top + 1;
}

template<class T>
void Stack<T>::print() const {
    for (int i = this->top  ; i >= 0 ; i--) {
        cout << this->data[i] << endl;
    }
    cout << "\n";
}

template<class T>
Stack<T> Stack<T>::reverse()
{
    Stack SR(*this);
    for(int i = top, j = 0  ; i >= 0 ; i-- , j++)
        SR.data[j] = data[i];
    return SR;
}


template<class T>
int Stack<T>::getObjCount() {
    return objCount;
}

template<class T>
const Stack<T> Stack<T>::operator=(const Stack<T> &right){
    if(this != &right){
        delete []data;
        data = right.data;
        top = right.top;
        data = new T[current_size];
        for (int i = 0; i <= top; i++) {
            data[i] = right.data[i];
        }
    }
    return *this;
};

template<class T>
const Stack<T> Stack<T>::operator+(const Stack<T> &right) {
    Stack<T> temp(initial_size + right.initial_size);
    for (int i = 0; i <= top ; i++) {
        temp.push(data[i]);
    }
    for (int i = 0; i <= right.top ; i++) {
        temp.push(right.data[i]);
    }
    return temp;
}


int main() {
    Stack<int> s1(7), s2(7), s3(20), s4;
    s1.push(10);
    s1.push(20);
    s1.push(30);
    s1.push(40);
    s2.push(50);
    s2.push(60);
    s2.push(70);
    s2.push(80);

//    cout << s1.getObjCount() << endl;
//    cout << s2.getObjCount() << endl;
    s3 = (s1 + s2);
    s3.print();
    return 0;
}

