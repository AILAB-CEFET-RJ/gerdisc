import React from 'react';

const Select = ({ options, onSelect, className="", label, name="", required=false }) => {
  if(!options) options = [];
  const handleChange = (event) => {
    onSelect(event.target.value);
  };

  return (
    <div className={className}>
    <label htmlFor={name}>{label}</label>
    <select required={required} defaultChecked={false} defaultValue={""} onChange={handleChange} name={name} id={name}>
      {options.map((option) => (
        <option key={option} value={option}>
          {option}
        </option>
      ))}
    </select>
    </div>
  );
};

export default Select;