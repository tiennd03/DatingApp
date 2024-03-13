#!/bin/bash

# Kiểm tra số lượng tham số đầu vào
if [ "$#" -eq 0 ]; then
    echo "Nhập kích thước hình và ký tự:"
    read size char
elif [ "$#" -eq 1 ]; then
    size=$1
    echo "Nhập ký tự:"
    read char
else
    size=$1
    char=$2
fi

# Vẽ hình
for ((i=size; i>=1; i--)); do
    for ((j=size; j>i; j--)); do
        echo -n " "
    done
    for ((k=1; k<=2*i; k++)); do
        echo -n "$char"
    done
    echo
done
