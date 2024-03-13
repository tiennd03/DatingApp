#!/bin/bash

# Xóa các file cũ nếu tồn tại
rm -f ~/ngay0803/*.sh

# Tạo 300 file mới
for ((i=1; i<=300; i++)); do
    filename="BuiXuanTien_${i}.sh"
    touch ~/ngay0803/"$filename"
    echo "Thông tin sinh viên: Họ và tên: Bui Xuan Tien, MSSV: 123456, Lớp quản lý: ABC, Lớp môn học: XYZ, Đề số: ${i}" > ~/ngay0803/"$filename"
    mv ~/ngay0803/"$filename" ~/ngay0803/"${filename%.sh}.txt"
done
