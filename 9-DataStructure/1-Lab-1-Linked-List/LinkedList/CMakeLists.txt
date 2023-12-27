cmake_minimum_required(VERSION 3.26)
project(LinkedList)

set(CMAKE_CXX_STANDARD 23)

add_executable(LinkedList main.cpp
        LinkedList.h
        Node.h
        Iterator.h)
