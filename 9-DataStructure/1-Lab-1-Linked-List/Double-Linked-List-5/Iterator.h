//
// Created by Mohamed on 12/27/2023.
//

#ifndef DOUBLE_LINKED_LIST_ITERATOR_H
#define DOUBLE_LINKED_LIST_ITERATOR_H
#include "Node.h"

template <class T>
class Iterator {
    Node<T> *currentNode;
public:
//
//    Iterator(){
//        currentNode = NULL;
//    }
    //To start the loop
    Iterator(Node<T> *node){
        currentNode = node;
    }
    //To get the value of the node's data
    int data(){
        return currentNode->data;
    }
    //Move next
    Iterator next(){
        currentNode = currentNode->next;
        return *this;
    }
    Node<T> * current(){
        return currentNode;
    }
};


#endif //DOUBLE_LINKED_LIST_ITERATOR_H
