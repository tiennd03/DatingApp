#!/bin/bash

while true; 
do
    echo "1. Present WD"
    echo "2. Input"
    echo "3. Information"
    echo "4. Exit"
    read -p "Chon mot lua chon: " choice

    case "$choice" in
        1|p|P)
            echo "Thu muc lam viec hien tai: $(pwd)"
            num_files=`find . -maxdepth 1 -type f | wc -l`
            num_thumuc=`find . -maxdepth 1 -type d | wc -l`
            echo "So file con: $((num_files - 1))"
            echo "So thu muc con: $((num_thumuc - 1))"
            ;;
        2|i|I)
            read -p "Nhap mot dia chi tuyet doi: " dctd
            echo "Dia chi tuyet doi: $dctd"
            ;;
        3|t|T)
            if [ -z "$dctd" ]; then
                echo "Nhap o phan 2 truoc."
            else
                if [ -e "$dctd" ]; then
                    echo "Duong dan: $dctd"
                    if [ -f "$dctd" ]; then
                        echo "La file"
                    elif [ -d "$dctd" ]; then
                        echo "La thu muc"
                    fi
                    echo "Quyen truy cap:"
                    ls -l "$dctd"
                else
                    echo "Duong dan khong ton tai"
                fi
            fi
            ;;
        4|e|E)
            read -p "Nhap ten cua ban: " ten
            echo "ByeBye $ten"
            exit 0
            ;;
        *)
            echo "Chon khong hop le, xin hay chon lai."
            ;;
    esac
done
