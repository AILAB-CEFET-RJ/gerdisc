import React from 'react';

const Select = ({ options, onSelect, className="", label, name="" }) => {
  if(!options) options = [];
  const handleChange = (event) => {
    onSelect(event.target.value);
  };

  return (
    <div className={className}>
    <label htmlFor={name}>{label}</label>
    <select onChange={handleChange} name={name} id={name}>
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