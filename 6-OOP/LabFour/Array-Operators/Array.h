//
// Created by Mohamed on 11/29/2023.
//

#ifndef ARRAY_OPERATORS_ARRAY_H
#define ARRAY_OPERATORS_ARRAY_H

template<class T>
class Array {
   int *data;
   int size;
   int currentIndex;
    void expandArray();
public:
    Array(int _size);
    Array(Array &right);
    ~Array();
    void fill();
    void display();
    void push(T item);
    void insert(T item, int Location);
    void deletee(int location);
    T find(T item);
    T getSize();
    T getCount();
    Array<int &> operator[](int index);
    const Array<T> operator=(const Array<T> &right);
    const Array<T> operator+(const Array<T> &right);
};


#endif //ARRAY_OPERATORS_ARRAY_H
