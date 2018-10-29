# Check Brackets

Application for checking the brackets order in a text.

## Output

Application outputs the list of errors found in the input text.
If no error is found then the application outputs the message "All brackets are ok"
If there are brackets that are opened and the closing bracket is not found or if it 
founds more closed brackets than opened bracket then the application outputs the message
"Not all brackets were ok. Check errors:" followed by a list of errors.

Each error contains three characters on the left side of the bracket that is not ok 
and three brackets on the right side.

## Example
```
Input text: "this {text} ) is not [{ok]}"
Output: Not all brackets were ok. Check errors:
        t}.).is
        {ok]}
        ot.[{ok
```
