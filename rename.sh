#use this script to custom projects name
new_name=$1

#change this variable if you already made manual changes
old_name="XXXXX"

grep --exclude="rename.sh" --exclude-dir={node_modules,bin,obj} -rl -e "$old_name" | while read file; do
    sed -i "s/$old_name/$new_name/g" $file
done

find . -name "*$old_name*" | sed "s/$old_name/$new_name/g" | sed "s/\(.*\)$new_name/\1$old_name/" | while read file; 
do
    mv "$file" "${file/"$old_name"/"$new_name"}"
done








