class Solution {
public:
    bool isValidIPv4Address(string IP) {
        int pos = 0;
        for(int i = 0; i < 4; i++) {
            int seperatePos = IP.find('.', pos);
            if (i == 3)
                seperatePos = IP.size() - pos;
            string subNumberStr = IP.substr(pos, seperatePos-pos);

            if(hasLeadingZero(subNumberStr) || isOverFlow(subNumberStr)) {
                return false;
            } else {
                pos = seperatePos + 1;
            }
        }

        return true;
    }

    bool isValidIPv6Address(string IP) {
        int pos = 0;
        for(int i = 0; i < 8; i++) {
            int seperatePos = IP.find(':', pos);
            if (i == 7)
                seperatePos = IP.size() - pos;
            string subNumberStr = IP.substr(pos, seperatePos-pos);
            // REDO THIS PART
            for (int i = 0; i < subNumberStr.size(); i++) {
                if(subNumberStr[i] > '9' || subNumberStr[i] < '0')
                    return false;
            }
            if(subNumberStr.size() > 4 || subNumberStr.size() == 0) {
                return false;
            } else {
                pos = seperatePos + 1;
            }
        }
        return true;
    }

    bool hasLeadingZero(string str) {
        if(str == ""|| str.length() > 3) return true;
        for (int i = 0; i < str.size(); i++) {
            if(str[i] > '9' || str[i] < '0')
                return true;
        }

        int strNum = std::stoi(str);

        if(strNum > 0) {
            if(str[0] == '0') {
                return true;
            } else {
                return false;
            }
        } else {
            return true;
        }
    }

    bool isOverFlow(string str) {
        for (int i = 0; i < str.size(); i++) {
            if(str[i] > '9' || str[i] < '0')
                return true;
        }
        if(str == "" || str.length() > 3) return true;
        int strNum = std::stoi(str);
        if(strNum > 255)
            return true;
        else
            return false;
    }

    string validIPAddress(string IP) {
        if(IP.find('.') != std::string::npos) {
            if(isValidIPv4Address(IP)) {
                return "IPv4";
            } else {
                return "Neither";
            }
        } else if(IP.find(':') != std::string::npos) {
            if(isValidIPv6Address(IP)) {
                return "IPv6";
            } else {
                return "Neither";
            }
        } else {
            return "Neither";
        }
    }

};