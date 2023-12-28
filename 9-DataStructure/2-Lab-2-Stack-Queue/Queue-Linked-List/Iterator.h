//
// Created by Mohamed on 12/26/2023.
//

#ifndef LINKEDLIST_ITERATOR_H
#define LINKEDLIST_ITERATOR_H
#include "Node.h"

template <class T>
class Iterator {
     Node<T> *currentNode;
public:

    Iterator(){
        currentNode = NULL;
    }
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


#endif //LINKEDLIST_ITERATOR_H
