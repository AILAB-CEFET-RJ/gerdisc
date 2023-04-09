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

template_name=$2

# Add help option
if [ "$1" == "--help" ]; then
  echo "Usage: $0 <name> <template_name>"
  echo "Copies files with names containing <template_name> and replaces it with <name>."
  exit 0
fi

# Find destination paths
paths=($(find . \( -name "${template_name}Entity.cs" -o -name "${template_name}Dto.cs" -o -name "${template_name}Mapper.cs" -o -name "${template_name}Controller.cs" -o -name "${template_name}Service.cs" -o -name "I${template_name}Service.cs" -o -name "${template_name}Repository.cs" -o -name "I${template_name}Repository.cs" \)))

# Create empty files if there were no files found
if [ ${#paths[@]} -eq 0 ]; then
  echo "No files found with name containing '$template_name' in the current directory and its subdirectories."
  exit 1
fi

# Copy and update files
for path in "${paths[@]}"; do
  new="${path//$template_name/$name}"
  mkdir -p "$(dirname $new)"
  if [ ! -f "$path" ]; then
    echo "Error: $path does not exist."
    exit 1
  fi
  
  if [ -f "$new" ]; then
    echo "Warning: $new already exists. Skipping creation of this file."
  else
    cp "$path" "$new"
    sed -i "s/$template_name/$name/g" "$new"
    sed -i "s/${template_name,}/${name,}/g" "$new"
    echo "Debug: $new created."
  fi
done

echo "Files copied and updated successfully."
