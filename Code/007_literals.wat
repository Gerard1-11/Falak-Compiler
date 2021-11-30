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
	(global $fails (mut i32) (i32.const 0))

	(func $assert
		(param $value1 i32)
		(param $value2 i32)
		(param $message i32)
		(result i32)
		(local $_temp i32)
		local.get $value1
		local.get $value2
		i32.eqz
		if
			global.get $fails
			i32.const 1
			i32.add
			global.set $fails
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
			i32.const 65
			call $add
			drop
			i32.const 115
			call $add
			drop
			i32.const 115
			call $add
			drop
			i32.const 101
			call $add
			drop
			i32.const 114
			call $add
			drop
			i32.const 116
			call $add
			drop
			i32.const 105
			call $add
			drop
			i32.const 111
			call $add
			drop
			i32.const 110
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
			i32.const 105
			call $add
			drop
			i32.const 108
			call $add
			drop
			i32.const 117
			call $add
			drop
			i32.const 114
			call $add
			drop
			i32.const 101
			call $add
			drop
			i32.const 58
			call $add
			drop
			i32.const 32
			call $add
			drop
			call $prints
			local.get $message
			call $prints
			call $println
		end
		)
	(func
		(export "main")
		(result i32)
		(local $_temp i32)
		(local $s i32)
		(local $a i32)
		(local $i i32)
		(local $n i32)
		i32.const 0
		global.set $fails
		i32.const 10
		i32.const 10
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
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 119
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 13
		i32.const 13
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
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 99
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 114
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
		i32.const 103
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 9
		i32.const 9
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
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 98
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 92
		i32.const 92
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
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 98
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 99
		call $add
		drop
		i32.const 107
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 104
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 39
		i32.const 39
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
		local.get $_temp
		local.get $_temp
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 103
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 113
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 111
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
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 34
		i32.const 34
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
		local.get $_temp
		local.get $_temp
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 100
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 98
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 113
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 111
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
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		call $assert
		i32.const 65
		i32.const 65
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
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 116
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
		i32.const 65
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 99
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 100
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 112
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 116
		call $add
		drop
		call $assert
		i32.const 8364
		i32.const 8364
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
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		local.get $_temp
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 105
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
		i32.const 108
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 99
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 100
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 112
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 116
		call $add
		drop
		call $assert
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
		i32.const 161
		call $add
		drop
		i32.const 8364
		call $add
		drop
		i32.const 115
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
		i32.const 110
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 241
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 8364
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 225
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 98
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 209
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 241
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 33
		call $add
		drop
		i32.const 10
		call $add
		drop
		local.set $s
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
		local.get $_temp
		i32.const 161
		call $add
		drop
		i32.const 8364
		call $add
		drop
		i32.const 115
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
		i32.const 110
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 241
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 8364
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 225
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 98
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 209
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 241
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 33
		call $add
		drop
		i32.const 10
		call $add
		drop
		local.set $a
		i32.const 0
		local.set $i
		local.get $s
		call $size
		local.set $n
		block $00001
			loop $00002

				local.get $i
				local.get $n
				i32.lt_s

				i32.eqz
				br_if $00001

				local.get $a
				local.get $i
				call $get
				local.get $s
				local.get $i
				call $get
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
				i32.const 101
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 111
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 110
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 115
				call $add
				drop
				i32.const 116
				call $add
				drop
				i32.const 114
				call $add
				drop
				i32.const 105
				call $add
				drop
				i32.const 110
				call $add
				drop
				i32.const 103
				call $add
				drop
				i32.const 32
				call $add
				drop
				i32.const 108
				call $add
				drop
				i32.const 105
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
				i32.const 108
				call $add
				drop
				call $assert
				local.get $i
				i32.const 1
				i32.add
				local.set $i

				br $00002
			end
		end
		global.get $fails
		call $printi
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
		local.get $_temp
		i32.const 32
		call $add
		drop
		i32.const 97
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 116
		call $add
		drop
		i32.const 105
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 110
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
		i32.const 105
		call $add
		drop
		i32.const 108
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 114
		call $add
		drop
		i32.const 101
		call $add
		drop
		i32.const 40
		call $add
		drop
		i32.const 115
		call $add
		drop
		i32.const 41
		call $add
		drop
		i32.const 32
		call $add
		drop
		i32.const 102
		call $add
		drop
		i32.const 111
		call $add
		drop
		i32.const 117
		call $add
		drop
		i32.const 110
		call $add
		drop
		i32.const 100
		call $add
		drop
		i32.const 46
		call $add
		drop
		call $prints
		call $println
		local.get $a
		call $prints
		))
