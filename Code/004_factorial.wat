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

	(func $iterative_factorial
		(param $n i32)
		(result i32)
		(local $_temp i32)
		(local $result i32)
		(local $i i32)
		i32.const 1
		local.set $result
		i32.const 2
		local.set $i
		block $00001
			loop $00002

				local.get $i
				local.get $n
				i32.le_s

				i32.eqz
				br_if $00001

				local.get $i
				local.get $result
				i32.mul
				local.set $result
				local.get $i
				i32.const 1
				i32.add
				local.set $i

				br $00002
			end
		end
		local.get $result
		return
		)
	(func $recursive_factorial
		(param $n i32)
		(result i32)
		(local $_temp i32)
		local.get $n
		i32.const 0
		i32.le_s
		if
			i32.const 1
			return
		else
			local.get $n
			i32.const 1
			i32.sub
			call $recursive_factorial
			local.get $n
			i32.mul
			return
		end
		)
	(func
		(export "main")
		(result i32)
		(local $_temp i32)
		(local $num i32)
		(local $option i32)
		block $00003
			loop $00004
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
				local.get $_temp
				local.get $_temp
				i32.const 73
				call $add
				drop
				i32.const 110
				call $add
				drop
				i32.const 112
				call $add
				drop
				i32.const 117
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 110
				call $add
				drop
				i32.const 117
				call $add
				drop
				i32.const 109
				call $add
				drop
				i32.const 98
				call $add
				drop
				i32.const 101
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 58
				call $add
				drop
				i32.const 32
				call $add
				drop
				call $prints
				call $readi
				local.set $num
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
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				i32.const 73
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
				i32.const 97
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 118
				call $add
				drop
				i32.const 101
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 102
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 99
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 108
				call $add
				drop
				i32.const 58
				call $add
				drop
				i32.const 32
				call $add
				drop
				call $prints
				local.get $num
				call $iterative_factorial
				call $printi
				call $println
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
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				local.get $_temp
				i32.const 82
				call $add
				drop
				i32.const 101
				call $add
				drop
				i32.const 99
				call $add
				drop
				i32.const 117
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 115
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 118
				call $add
				drop
				i32.const 101
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 102
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 99
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 108
				call $add
				drop
				i32.const 58
				call $add
				drop
				i32.const 32
				call $add
				drop
				call $prints
				local.get $num
				call $recursive_factorial
				call $printi
				call $println
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
				i32.const 67
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 109
				call $add
				drop
				i32.const 112
				call $add
				drop
				i32.const 117
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 101
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 110
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 104
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
				i32.const 102
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 99
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 97
				call $add
				drop
				i32.const 108
				call $add
				drop
				i32.const 63
				call $add
				drop
				i32.const 32
				call $add
				drop
				call $prints
				call $reads
				local.set $option
				local.get $option
				call $size
				i32.const 0
				i32.eq
				if
					i32.const 78
					local.set $option
				else
					local.get $option
					i32.const 0
					call $get
					local.set $option
				end

				local.get $option
				i32.const 89
				i32.eq

				i32.eqz
				br_if $00003

				br $00004
			end
		end
		))
