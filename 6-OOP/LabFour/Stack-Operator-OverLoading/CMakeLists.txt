cmake_minimum_required(VERSION 3.26)
project(Stack_Operator_OverLoading)

set(CMAKE_CXX_STANDARD 14)

include_directories(.)

add_executable(Stack_Operator_OverLoading
        Stack.cpp
        Stack.h)
