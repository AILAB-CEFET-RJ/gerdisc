#!/bin/bash

set -e

# Check if the name parameter is provided
if [ -z "$1" ]; then
  echo "Please provide the name of the entity as a parameter."
  exit 1
fi

# Set the name variable
name=$1

# Set the file paths
entity_path="Models/Entities/${name}Entity.cs"
dto_path="Models/DTOs/${name}Dto.cs"
mapper_path="Models/Mapper/${name}Mapper.cs"
controller_path="Controllers/${name}Controller.cs"
service_path="Services/${name}Service.cs"
service_interface_path="Services/Interfaces/I${name}Service.cs"
repository_interface_path="Infrastructure/Repositories/${name}/I${name}Repository.cs"
repository_path="Infrastructure/Repositories/${name}/${name}Repository.cs"

# Create the directories if they don't exist
mkdir -p $(dirname $entity_path)
mkdir -p $(dirname $dto_path)
mkdir -p $(dirname $mapper_path)
mkdir -p $(dirname $controller_path)
mkdir -p $(dirname $service_path)
mkdir -p $(dirname $service_interface_path)
mkdir -p $(dirname $repository_interface_path)
mkdir -p $(dirname $repository_path)

# Check if the second parameter is provided
if [ -z "$2" ]; then
  # Create the files
  touch $entity_path
  touch $dto_path
  touch $mapper_path
  touch $controller_path
  touch $service_path
  touch $service_interface_path
  touch $repository_interface_path
  touch $repository_path

  echo "Files created successfully."
  exit 0
fi

# Set the name_to_copy variable
name_to_copy=$2

# Set the file paths for the copied files
entity_path_copy="Models/Entities/${name_to_copy}Entity.cs"
dto_path_copy="Models/DTOs/${name_to_copy}Dto.cs"
mapper_path_copy="Models/Mapper/${name_to_copy}Mapper.cs"
controller_path_copy="Controllers/${name_to_copy}Controller.cs"
service_interface_path_copy="Services/Interfaces/I${name_to_copy}Service.cs"
service_path_copy="Services/${name_to_copy}Service.cs"
repository_interface_path_copy="Infrastructure/Repositories/${name_to_copy}/I${name_to_copy}Repository.cs"
repository_path_copy="Infrastructure/Repositories/${name_to_copy}/${name_to_copy}Repository.cs"

# Check if the copied files exist
if [ ! -f $entity_path_copy ] || [ ! -f $dto_path_copy ] || [ ! -f $mapper_path_copy ] || [ ! -f $controller_path_copy ] || [ ! -f $service_interface_path_copy ] || [ ! -f $service_path_copy ] || [ ! -f $repository_interface_path_copy ] || [ ! -f $repository_path_copy ]; then
  echo "Error: One or more of the copied files do not exist."
  exit 1
fi

# Set the source and destination paths
source_paths=("$entity_path_copy" "$dto_path_copy" "$mapper_path_copy" "$controller_path_copy" "$service_path_copy" "$service_interface_path_copy" "$repository_interface_path_copy" "$repository_path_copy")
dest_paths=("$entity_path" "$dto_path" "$mapper_path" "$controller_path" "$service_path" "$service_interface_path" "$repository_interface_path" "$repository_path")

# Loop over the source and destination paths
for i in "${!source_paths[@]}"; do
    source="${source_paths[$i]}"
    dest="${dest_paths[$i]}"
    cp "$source" "$dest"
    sed -i "s/${name_to_copy}/${name}/g" "$dest"
done
