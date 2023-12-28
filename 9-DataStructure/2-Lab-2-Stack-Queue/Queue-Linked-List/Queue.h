//
// Created by Mohamed on 12/28/2023.
//

#ifndef QUEUE_LINKED_LIST_QUEUE_H
#define QUEUE_LINKED_LIST_QUEUE_H
#include "LinkedList.h"

template <class T>
class Queue {
     LinkeList<T> List;
     int length;
public:
     Queue(){this->length = 0;}

     bool isEmpty(){return length <= 0;}

     void enQueue(T _data){
         this->List.insertFirst(_data);
         this->length++;
     }

     int deQueue(T &data){
         if (isEmpty())
             return 0;
         data = this->List.getTailData();
         this->List.deleteLast();
         length--;
         return 1;

     }

     int peek(T &data){
        if(isEmpty())
            return 0;
        data =  this->List.getTailData();
        return 1;
    }

     void print(){ this->List.printList();}

     int getLength(){return length;}

};


#endif //QUEUE_LINKED_LIST_QUEUE_H
