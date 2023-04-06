#!/bin/bash

set -e

if [ -z "$1" ]; then
  echo "Please provide the name of the entity as a parameter."
  exit 1
fi

name=$1
entity_path="Models/Entities/${name}Entity.cs"
dto_path="Models/DTOs/${name}Dto.cs"
mapper_path="Models/Mapper/${name}Mapper.cs"
controller_path="Controllers/${name}Controller.cs"
service_path="Services/${name}Service.cs"
service_interface_path="Services/Interfaces/I${name}Service.cs"
repository_interface_path="Infrastructure/Repositories/${name}/I${name}Repository.cs"
repository_path="Infrastructure/Repositories/${name}/${name}Repository.cs"

paths=("$entity_path" "$dto_path" "$mapper_path" "$controller_path" "$service_path" "$service_interface_path" "$repository_interface_path" "$repository_path")

for path in "${paths[@]}"; do
  mkdir -p "$(dirname $path)"
done

if [ -z "$2" ]; then
  for path in "${paths[@]}"; do
    touch "$path"
  done

  echo "Files created successfully."
  exit 0
fi

name_to_copy=$2
source_paths=()
dest_paths=()

for path in "${paths[@]}"; do
  source="${path//${name}/${name_to_copy}}"
  source_paths+=("$source")
  dest_paths+=("$path")
done

for i in "${!source_paths[@]}"; do
  source="${source_paths[$i]}"
  dest="${dest_paths[$i]}"
  
  if [ ! -f "$source" ]; then
    echo "Error: $source does not exist."
    exit 1
  fi
  
  cp "$source" "$dest"
  sed -i "s/$name_to_copy/$name/g" "$dest"
done

echo "Files copied and updated successfully."
