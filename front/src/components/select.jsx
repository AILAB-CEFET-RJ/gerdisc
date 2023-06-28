import React from 'react';

const Select = ({ options, onSelect, className="", label, name="", required=false, disabled=false, defaultValue="" }) => {
  var selected = defaultValue
  if(!options) options = [];
  const handleChange = (event) => {
    onSelect(event.target.value);
    selected = event.target.value
  };

  return (
    <div className={className}>
    <label htmlFor={name}>{label}</label>
    <select disabled={disabled} required={required} onChange={handleChange} name={name} id={name}>
      {options.map((option) => (
        <option key={option} value={option} selected={option === selected}>
          {option}
        </option>
      ))}
    </select>
    </div>
  );
};

export default Select;