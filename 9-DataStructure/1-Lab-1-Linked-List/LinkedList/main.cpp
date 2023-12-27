#include <iostream>
#include "LinkedList.h"

using namespace std;

int main() {
    LinkeList<int> List;
    List.insertLast(10);
    List.insertLast(20);
    List.insertLast(30);
    List.insertLast(40);
    List.insertLast(50);
    List.insertLast(60);
    List.printList();
    List.insertAfter(20, 80);
    List.printList();
    List.checkIfExisting(10);
    List.checkIfExisting(1);
    List.insertBefore(30, 77);
    List.printList();
    List.deleteNode(10);
    List.deleteNode(60);
    List.deleteNode(77);
    List.printList();
    cout<< List.length << endl;
    List.reverse();
    List.printList();
    return 0;
}
