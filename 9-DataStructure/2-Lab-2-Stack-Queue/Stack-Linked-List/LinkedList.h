//
// Created by Mohamed on 12/26/2023.
//

#ifndef LINKEDLIST_LINKEDLIST_H
#define LINKEDLIST_LINKEDLIST_H
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
    Node<T> *findNodeBefore(Node<T> *node){
        for(Iterator<T> it = this->begin() ; it.current() != NULL ; it.next()){
            if(it.current()->next == node){
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

    void printStack(){
        while (head != NULL){
            cout<< getHead() << "-> ";
            deleteFirst();
        }
        cout<<"\n";
    }

    bool isEmpty(){
        return head == NULL;
    }

    //Insert node at the end of the list
    void insertLast(T _data){
        Node<T> *newNode = new Node(_data);
        if(this->head == NULL){
            this->head = newNode;
            this->tail = newNode;
        }
        else{
            this->tail->next = newNode;
            this->tail = newNode;
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

    //Insert after node
    void insertAfter(T _data, T newData){

        if(find(_data)){
            Node<T> *node;
            Node<T> *newNode = new Node(newData);
            node = find(_data);

            newNode->next = node->next;
            node->next = newNode;

            if(newNode->next == NULL){
                this->tail = newNode;
            }
        }
        else{
            cout << "Can't insert" << endl;
        }
        length++;
    }

    void insertBefore(int _data, int newData){
        if(find(_data)){

            Node<T> *node;
            Node<T> *nodeBefore;
            Node<T> *newNode = new Node(newData);

            node = find(_data);
            newNode->next = node;
            nodeBefore = findNodeBefore(node);

            if(nodeBefore == NULL)
                this->head = newNode;
            else
                nodeBefore->next = newNode;
        }
        length++;
    }

    void deleteNode(int _data){

        if(isEmpty()){
            return;
        }
        Node<T> *node;
        Node<T> *nodeBefore;

        node = find(_data);

        if(length == 1){
            head = NULL;
            tail = NULL;
        }
        else if(head == node){
            head = node->next;
        }
        else{
            nodeBefore = findNodeBefore(node);
            if (node == tail){
                tail = nodeBefore;
                tail->next = NULL;
            }
            else{
                nodeBefore->next = node->next;
            }
        }
        delete node;
        length--;
    }

    void reverse(){
        Node<T> *prev, *after, *curr;
        prev = NULL;
        curr = head;
        after = head->next;
        while (after != NULL || curr != NULL){
            after = curr->next;
            curr->next = prev;
            prev = curr;
            curr = after;
        }
        head = prev;
    }

    void insertFirst(T _data){
        Node<T> *newNode = new Node(_data);
        if(head == NULL)
            this->head = this->tail = newNode;
        else{
            newNode->next = this->head;
            this->head = newNode;
        }
        length++;
    }

    void deleteFirst(){
            if(this->head == NULL)
                return;
            Node<T> *temp;
            temp = this->head;
            this->head = this->head->next;
            temp->next = NULL;
            delete temp;
            this->length--;
    }

    int getHead(){return this->head->data;}
};

#endif //LINKEDLIST_LINKEDLIST_H
