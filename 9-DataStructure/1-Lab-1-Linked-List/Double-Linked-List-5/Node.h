//
// Created by Mohamed on 12/27/2023.
//

#ifndef DOUBLE_LINKED_LIST_NODE_H
#define DOUBLE_LINKED_LIST_NODE_H


template <class T>
class Node {
public:
    T data;
    Node *next;
    Node *back;
    Node(T _data){
        this->data = _data;
        this->next = NULL;
        this->back = NULL;
    }
};;


#endif //DOUBLE_LINKED_LIST_NODE_H
