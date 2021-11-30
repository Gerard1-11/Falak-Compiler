;; WebAssembly text format code generated by the falak compiler.

(module
 (import "falak" "printi" (func $printi (param i32)))
 (import "falak" "printc" (func $printc (param i32)))
 (import "falak" "prints" (func $prints (param i32)))
 (import "falak" "println" (func $println))
 (import "falak" "readi" (func $readi (result i32)))
 (import "falak" "reads" (func $reads (result i32)))
 (import "falak" "new" (func $new (param i32) (result i32)))
 (import "falak" "size" (func $size (param i32) (result i32)))
 (import "falak" "add" (func $add (param i32) (param i32) (result i32)))
 (import "falak" "get" (func $get (param i32) (param i32) (result i32)))
 (import "falak" "set" (func $set (param i32) (param i32) (param i32)))

	(func $is_leap_year
		(param $y i32)
		(result i32)
		(local $_temp i32)
		local.get $y
		i32.const 4
		i32.rem_s
		i32.const 0
		i32.eq
		if
			local.get $y
			i32.const 100
			i32.rem_s
			i32.const 0
			i32.eq
			if
				local.get $y
				i32.const 400
				i32.rem_s
				i32.const 0
				i32.eq
				if
					i32.const 1
					return
				else
					i32.const 0
					return
				end
			else
				i32.const 1
				return
			end
		else
			i32.const 0
			return
		end
		)
	(func $number_of_days_in_month
		(param $y i32)
		(param $m i32)
		(result i32)
		(local $_temp i32)
		(local $result i32)
		local.get $m
		i32.const 2
		i32.eq
		if
			local.get $y
			call $is_leap_year
			if
				i32.const 29
				local.set $result
			else
				i32.const 28
				local.set $result
			end
		else
			local.get $m
			i32.const 4
			i32.eq
			if(result i32)
				i32.const 1
			else
				local.get $m
				i32.const 6
				i32.eq
				i32.eqz
				i32.eqz
			end
			if(result i32)
				i32.const 1
			else
				local.get $m
				i32.const 9
				i32.eq
				i32.eqz
				i32.eqz
			end
			if(result i32)
				i32.const 1
			else
				local.get $m
				i32.const 11
				i32.eq
				i32.eqz
				i32.eqz
			end
			if
				i32.const 30
				local.set $result
			else
				i32.const 31
				local.set $result
			end
		end
		local.get $result
		return
		)
	(func $next_day
		(param $y i32)
		(param $m i32)
		(param $d i32)
		(result i32)
		(local $_temp i32)
		local.get $d
		local.get $y
		local.get $m
		call $number_of_days_in_month
		i32.eq
		if
			local.get $m
			i32.const 12
			i32.eq
			if
				i32.const 0
				call $new
				local.set $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $y
				i32.const 1
				i32.add
				call $add
				drop
				i32.const 1
				call $add
				drop
				i32.const 1
				call $add
				drop
				return
			else
				i32.const 0
				call $new
				local.set $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $y
				call $add
				drop
				local.get $m
				i32.const 1
				i32.add
				call $add
				drop
				i32.const 1
				call $add
				drop
				return
			end
		else
			i32.const 0
			call $new
			local.set $_temp
			local.get $_temp
			local.get $_temp
			local.get $_temp
			local.get $_temp
			local.get $y
			call $add
			drop
			local.get $m
			call $add
			drop
			local.get $d
			i32.const 1
			i32.add
			call $add
			drop
			return
		end
		)
	(func $print_next_day
		(param $y i32)
		(param $m i32)
		(param $d i32)
		(result i32)
		(local $_temp i32)
		(local $next i32)
		i32.const 0
		call $new
		local.set $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 84
		call $add
		drop
		i32.const 104
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 100
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 121
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 102
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		call $prints
		local.get $y
		call $printi
		i32.const 47
		call $printc
		local.get $m
		call $printi
		i32.const 47
		call $printc
		local.get $d
		call $printi
		i32.const 0
		call $new
		local.set $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 32
		call $add
		drop
		call $prints
		local.get $y
		local.get $m
		local.get $d
		call $next_day
		local.set $next
		local.get $next
		i32.const 0
		call $get
		call $printi
		i32.const 47
		call $printc
		local.get $next
		i32.const 1
		call $get
		call $printi
		i32.const 47
		call $printc
		local.get $next
		i32.const 2
		call $get
		call $printi
		call $println
		)
	(func
		(export "main")
		(result i32)
		(local $_temp i32)
		i32.const 2020
		i32.const 2
		i32.const 28
		call $print_next_day
		i32.const 2021
		i32.const 2
		i32.const 13
		call $print_next_day
		i32.const 2021
		i32.const 2
		i32.const 28
		call $print_next_day
		i32.const 2021
		i32.const 12
		i32.const 31
		call $print_next_day
		))