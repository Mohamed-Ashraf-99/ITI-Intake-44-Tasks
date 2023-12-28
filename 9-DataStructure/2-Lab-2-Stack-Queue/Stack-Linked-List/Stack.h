//
// Created by Mohamed on 12/27/2023.
//

#ifndef STACK_LINKED_LIST_STACK_H
#define STACK_LINKED_LIST_STACK_H
#include "LinkedList.h"

template <class T>
class Stack {
    LinkeList<T> dataList;
    int length;
public:
    Stack(){length = 0;}

    void push(T _data){
        this->dataList.insertFirst(_data);
        length++;
    }

    bool pop(T &data){
        if(isEmpty())
            return false;
        data = this->dataList.getHead();
        this->dataList.deleteFirst();
        length--;
        return true;
    }

    void print(){this->dataList.printList();}

    bool isEmpty(){return length <= 0;}

    bool peek(T &data){
        if(isEmpty())
            return false;
        data =  this->dataList.getHead();
        return true;
    }

    int getLength(){return length;}

};


#endif //STACK_LINKED_LIST_STACK_H
