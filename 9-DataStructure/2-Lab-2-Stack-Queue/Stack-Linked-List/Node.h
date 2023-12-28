//
// Created by Mohamed on 12/26/2023.
//

#ifndef LINKEDLIST_NODE_H
#define LINKEDLIST_NODE_H

template <class T>
class Node {
public:
    T data;
    Node *next;
    Node(T _data){
        this->data = _data;
        this->next = NULL;
    }
};


#endif //LINKEDLIST_NODE_H
