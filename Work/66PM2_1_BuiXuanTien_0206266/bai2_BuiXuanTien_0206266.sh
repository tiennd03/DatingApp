#!/bin/bash

# Khởi tạo biến kiểm tra
found_u=false
last_u_arg=""

# Duyệt qua tất cả các tham số
for arg in "$@"; do
    # Nếu gặp tham số -u
    if [ "$arg" = "-u" ]; then
        found_u=true
    # Nếu đã gặp tham số -u trước đó và tham số hiện tại không phải là -u
    elif [ "$found_u" = true ]; then
        # Lưu trữ tham số ngay sau vị trí xuất hiện -u lần cuối cùng
        last_u_arg="$arg"
        found_u=false
    fi
done

# Nếu tìm thấy tham số -u và có tham số ngay sau
if [ -n "$last_u_arg" ]; then
    echo "Hello $last_u_arg"
fi
