//
// Created by Mohamed on 12/27/2023.
//

#ifndef DOUBLE_LINKED_LIST_LINKEDLIST_H
#define DOUBLE_LINKED_LIST_LINKEDLIST_H
#include "Node.h"
#include "Iterator.h"

using namespace std;

template <class T>
class LinkeList{
    Node<T> *head;
    Node<T> *tail;
    Iterator<T> begin(){
        Iterator itr(this->head);
        return itr;
    }
    Node<T> *find(int _data){
        for(Iterator<T> it = this->begin() ; it.current() != NULL ; it.next()){
            if(it.data() == _data){
                return it.current();
            }
        }
        return NULL;
    }
public:
    int length = 0;
    LinkeList(){
        head = NULL;
        tail = NULL;
    }

    void printList(){
        for(Iterator<T> it = this->begin() ; it.current() != NULL ; it.next()){
            cout<< it.data() << "-> ";
        }
        cout<<"\n";
    }

    bool isEmpty(){
        return head == NULL;
    }


    void insertLast(T _data){
        Node<T> *newNode = new Node(_data);
        if(head ==  NULL)
            head = tail = newNode;
        else{
            tail->next =  newNode;
            newNode->back = tail;
            newNode->next = NULL;
            tail = newNode;
        }
        length++;
    }


    void checkIfExisting(int _data){
        int flag = 0;
        for(Iterator<T> it = this->begin() ; it.current() != NULL ; it.next()){
            if(it.data() == _data)
                flag = 1;
        }
        if(flag)
            cout << "Node is existing" << endl;
        else
            cout << "Node is not existing" << endl;
    }


    void insertAfter(T _data, T newData){

        if (find(_data)){
            Node<T> *node;
            Node<T> *newNode = new Node(newData);
            node = find(_data);

            if(head == tail)
                head = tail = newNode;
            else{
                newNode->next = node->next;
                newNode->back = node;
                node->next = newNode;
                if (newNode->next == NULL){
                    this->tail = newNode;
                }
                else{
                    newNode->next->back = newNode;
                }
            }
            length++;
        }
    }

    void insertBefore(int _data, int newData){
               if(find(_data)){

                   Node<T> *node;
                   Node<T> *newNode = new Node(newData);
                   node = find(_data);
                   if(head == tail)
                       head = tail = newNode;
                   else{
                       //check if it's the head
                       if(node->back == NULL){
                           newNode->next = head;
                           newNode->back = NULL;
                           head = newNode;
                       }
                       else if (node->next == NULL){
                           tail->back->next = newNode;
                           newNode->back = tail->back;
                           newNode->next = tail;
                           tail->back = newNode;
                       }
                       else{
                           newNode->next = node;
                           newNode->back = node->back;
                           node->back->next = newNode;
                           node->back = newNode;
                       }
                   }
               }
    }


    void deleteNode(int _data) {
        if(head == NULL)
            return;
        else if(find(_data)){
            Node<T> *node;
            node = find(_data);
            if (this->head == this->tail) {
                this->head = NULL;
                this->tail = NULL;
            } else if (node->back == NULL) {
                this->head = node->next;
                node->next->back = NULL;
            } else if (node->next == NULL) {
                this->tail = node->back;
                node->back->next = NULL;
            } else {
                node->back->next = node->next;
                node->next->back = node->back;
            }
            delete node;
            length--;
        }
    }

    void reverse(){
           Node<T> *temp = tail;
        while (temp != NULL){
            cout << temp->data << "-> ";
            temp = temp->back;
        }
    }

};


#endif //DOUBLE_LINKED_LIST_LINKEDLIST_H
