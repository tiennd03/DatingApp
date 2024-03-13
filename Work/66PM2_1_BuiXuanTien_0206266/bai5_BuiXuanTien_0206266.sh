#!/bin/bash

# Đọc file và lấy danh sách email
emails=$(awk -F ',,' '{print $NF}' ThiSinhDuThi.txt | tail -n +2)

# Khởi tạo biến đếm cho từng loại email
gmail_count=0
hotmail_count=0
ymail_count=0
yahoo_count=0
rocketmail_count=0
hotmail_count=0
rocketmail_count=0
ymail_count=0
other_count=0

# Duyệt qua danh sách email và tăng biến đếm cho từng loại
for email in $emails; do
    domain=$(echo "$email" | awk -F '@' '{print $2}')
    case "$domain" in
        "gmail.com")
            ((gmail_count++))
            ;;
        "hotmail.com")
            ((hotmail_count++))
            ;;
        "ymail.com")
            ((ymail_count++))
            ;;
        "yahoo.com")
            ((yahoo_count++))
            ;;
        "rocketmail.com")
            ((rocketmail_count++))
            ;;
        *)
            ((other_count++))
            ;;
    esac
done

# In ra số lượng nhà cung cấp email mỗi loại
echo "Số lượng nhà cung cấp email mỗi loại:"
echo "Gmail: $gmail_count"
echo "Hotmail: $hotmail_count"
echo "Ymail: $ymail_count"
echo "Yahoo: $yahoo_count"
echo "Rocketmail: $rocketmail_count"
echo "Other: $other_count"
