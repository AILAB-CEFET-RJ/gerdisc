#!/bin/bash

set -e

if [ -z "$1" ]; then
  echo "Please provide the name of the entity as a parameter."
  exit 1
fi

name=$1

if [ -z "$2" ]; then
  echo "Please provide the name of the entity to copy as a second parameter."
  exit 1
fi

name_to_copy=$2

# Find destination paths
paths=($(find . \( -name "${name_to_copy}Entity.cs" -o -name "${name_to_copy}Dto.cs" -o -name "${name_to_copy}Mapper.cs" -o -name "${name_to_copy}Controller.cs" -o -name "${name_to_copy}Service.cs" -o -name "I${name_to_copy}Service.cs" -o -name "${name_to_copy}Repository.cs" -o -name "I${name_to_copy}Repository.cs" \)))

# Create empty files if there were no files found
if [ ${#paths[@]} -eq 0 ]; then
  echo "No files found with name containing '$name_to_copy' in the current directory and its subdirectories."
  exit 1
fi

# Copy and update files
for path in "${paths[@]}"; do
  new="${path//$name_to_copy/$name}"
  mkdir -p "$(dirname $new)"
  if [ ! -f "$path" ]; then
    echo "Error: $path does not exist."
    exit 1
  fi
  
  if [ -f "$new" ]; then
    echo "Warning: $new already exists. Skipping creation of this file."
  else
    cp "$path" "$new"
    sed -i "s/$name_to_copy/$name/g" "$new"
    sed -i "s/${name_to_copy,}/${name,}/g" "$new"
    echo "Debug: $new created."
  fi
done

echo "Files copied and updated successfully."
