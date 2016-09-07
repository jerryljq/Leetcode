// Leetcode Question 344 - Easy
// Programming language: C
// Created by Jerry Li on 2016/9/6.
//

char* reverseString(char* s) {
    for(int i = 0; i < strlen(s)/2; i++) {
        char temp = s[i];
        s[i] = s[strlen(s)-1-i];
        s[strlen(s)-1-i] = temp;
    }
    return s;
}