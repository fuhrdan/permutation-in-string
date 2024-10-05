//*****************************************************************************
//** 567. Permutation in String   leetcode                                   **
//*****************************************************************************


bool checkInclusion(char* s1, char* s2) {
    int len1 = strlen(s1);
    int len2 = strlen(s2);

    // If s1 is longer than s2, it's impossible for s2 to contain any permutation of s1.
    if (len1 > len2) {
        return false;
    }

    int countS1[26] = {0};  // Frequency array for s1
    int window[26] = {0};   // Frequency array for the current window in s2

    // Populate frequency array for s1
    for (int i = 0; i < len1; i++) {
        countS1[s1[i] - 'a']++;
    }

    // Populate initial window in s2
    for (int i = 0; i < len1; i++) {
        window[s2[i] - 'a']++;
    }

    // Check if the initial window is a permutation of s1
    bool matches = true;
    for (int i = 0; i < 26; i++) {
        if (countS1[i] != window[i]) {
            matches = false;
            break;
        }
    }
    if (matches) {
        return true;
    }

    // Slide the window over the rest of s2
    for (int i = len1; i < len2; i++) {
        // Remove the character that goes out of the window
        window[s2[i - len1] - 'a']--;

        // Add the new character that comes into the window
        window[s2[i] - 'a']++;

        // Check if the current window is a permutation of s1
        matches = true;
        for (int j = 0; j < 26; j++) {
            if (countS1[j] != window[j]) {
                matches = false;
                break;
            }
        }
        if (matches) {
            return true;
        }
    }

    return false;
}